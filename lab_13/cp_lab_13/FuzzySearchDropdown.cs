using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace cp_lab_13
{
    /// <summary>
    /// Reusable component that shows a non-destructive fuzzy-results dropdown
    /// for a ToolStripTextBox. It is UI-framework specific (WinForms ToolStripTextBox).
    /// </summary>
    public class FuzzySearchDropdown : IDisposable
    {
        private readonly Form _ownerForm;
        private readonly ToolStripTextBox _textBox;
        private readonly Func<string, List<Tuple<int, int>>> _searchFunc;
        private readonly Func<int, string> _displayFunc;
        private readonly Action<int> _onSelect;
        private readonly ToolStripDropDown _dropDown;
        private readonly ListBox _listBox;
        private readonly List<int> _resultIndices = new List<int>();
        private int _maxItems = 8;
        private bool _subscribedTextBoxControl = false;

        public int MaxItems
        {
            get => _maxItems;
            set => _maxItems = Math.Max(1, value);
        }

        public FuzzySearchDropdown(Form ownerForm,
                                   ToolStripTextBox searchTextBox,
                                   Func<string, List<Tuple<int, int>>> searchFunc,
                                   Func<int, string> displayFunc,
                                   Action<int> onSelect)
        {
            _ownerForm = ownerForm ?? throw new ArgumentNullException(nameof(ownerForm));
            _textBox = searchTextBox ?? throw new ArgumentNullException(nameof(searchTextBox));
            _searchFunc = searchFunc ?? throw new ArgumentNullException(nameof(searchFunc));
            _displayFunc = displayFunc ?? throw new ArgumentNullException(nameof(displayFunc));
            _onSelect = onSelect ?? throw new ArgumentNullException(nameof(onSelect));

            _listBox = new ListBox
            {
                IntegralHeight = false,
                SelectionMode = SelectionMode.One,
                HorizontalScrollbar = false
            };

            // no keyboard or focus-driven selection behavior: only show suggestions
            // _listBox.DoubleClick, KeyDown and LostFocus handlers intentionally NOT attached

            var host = new ToolStripControlHost(_listBox)
            {
                Padding = Padding.Empty,
                Margin = Padding.Empty,
                AutoSize = false
            };

            _dropDown = new ToolStripDropDown
            {
                // Disable AutoClose so typing in the textbox won't automatically close the dropdown while text changes
                AutoClose = false,
                Padding = Padding.Empty,
            };
            _dropDown.Items.Add(host);

            _textBox.Control.LostFocus += TextBoxControl_LostFocus;
            _subscribedTextBoxControl = true;
        }

        // Public method: call from the ToolStripTextBox.TextChanged event handle
        public void ShowFor(string pattern)
        {
            // Don't Hide() first — avoid focus flicker while updating suggestions

            if (string.IsNullOrWhiteSpace(pattern))
            {
                Hide();
                return;
            }

            var matches = _searchFunc(pattern);
            if (matches == null || matches.Count == 0)
            {
                Hide();
                return;
            }

            _resultIndices.Clear();
            _listBox.Items.Clear();

            int count = Math.Min(_maxItems, matches.Count);
            int width = 250;
            for (int i = 0; i < count; i++)
            {
                int rowIndex = matches[i].Item1;
                int score = matches[i].Item2;
                string display = _displayFunc(rowIndex) ?? string.Empty;
                _resultIndices.Add(rowIndex);
                string shown = $"{display}   ({score})";
                _listBox.Items.Add(shown);
                width = Math.Max(width, TextRenderer.MeasureText(shown, _listBox.Font).Width + 30);
            }

            int itemHeight = _listBox.ItemHeight;
            int height = Math.Min(count, _maxItems) * itemHeight + 4;
            _listBox.Size = new Size(width, height);

            // compute show location relative to the ToolStrip that owns the ToolStripTextBox
            var ownerStrip = _textBox.Owner;
            var host = (ToolStripControlHost)_dropDown.Items[0];
            host.Size = _listBox.Size;

            if (ownerStrip != null)
            {
                // Anchor the dropdown to the parent ToolStrip and position under the ToolStripTextBox
                // ensure hosted control is visible before showing
                host.Control.Visible = true;
                _dropDown.Show(ownerStrip, _textBox.Bounds.Location + new Size(0, _textBox.Bounds.Height));
            }
            else if (_textBox.Control != null)
            {
                // fallback: anchor to the underlying control when there is no owner strip
                host.Control.Visible = true;
                _dropDown.Show(_textBox.Control, new Point(0, _textBox.Control.Height));
            }
            else
            {
                // nothing sensible to anchor to
                return;
            }
        }

        public void Hide()
        {
            if (_dropDown != null && _dropDown.Visible)
            {
                // Close the drop-down (preferred over Hide for ToolStripDropDown to remove layered window)
                try
                {
                    _dropDown.Close(ToolStripDropDownCloseReason.CloseCalled);
                }
                catch
                {
                    // fall back to Hide if Close throws for any reason
                    _dropDown.Hide();
                }

                // ensure hosted control is not left visible
                var host = _dropDown.Items.Count > 0 ? _dropDown.Items[0] as ToolStripControlHost : null;
                if (host?.Control != null)
                    host.Control.Visible = false;

                // force repaint of underlying window to remove any leftover shadow/artifacts
                try
                {
                    _ownerForm?.Invalidate(true);
                    _ownerForm?.Update();
                }
                catch { }
            }
        }

        // Public KeyDown handler: only keep Escape to hide the dropdown (no selection navigation)
        // Call this from the text box KeyDown event.
        public void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (_dropDown.Visible)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Hide();
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    // select the top item (path of least resistance)
                    if (_listBox.Items.Count > 0)
                    {
                        SelectByListIndex(0);
                        Hide();
                        // prevent ding / further processing in textbox
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                }
            }
        }

        private void ListBox_KeyDown(object sender, KeyEventArgs e)
        {
            // kept for compatibility but NOT attached; left intentionally empty
        }

        private void ListBox_DoubleClick(object sender, EventArgs e)
        {
            // kept for compatibility but NOT attached; left intentionally empty
        }

        private void ListBox_LostFocus(object sender, EventArgs e)
        {
            // kept for compatibility but NOT attached; left intentionally empty
        }

        private void TextBoxControl_LostFocus(object sender, EventArgs e)
        {
            _ownerForm.BeginInvoke(new Action(() =>
            {
                if (_textBox.Control == null || !_textBox.Control.Focused)
                {
                    Hide();
                }
            }));
        }

        private void SelectByListIndex(int listIndex)
        {
            if (listIndex < 0 || listIndex >= _resultIndices.Count)
                return;

            int underlyingIndex = _resultIndices[listIndex];
            try
            {
                _onSelect(underlyingIndex);
            }
            catch
            {
                // swallow selection exceptions to avoid breaking UI
            }
        }

        public void Dispose()
        {
            // listbox handlers were not attached, so no need to remove them.

            if (_subscribedTextBoxControl && _textBox.Control != null)
            {
                _textBox.Control.LostFocus -= TextBoxControl_LostFocus;
                _subscribedTextBoxControl = false;
            }

            _dropDown.Dispose();
            _listBox.Dispose();
        }
    }
}