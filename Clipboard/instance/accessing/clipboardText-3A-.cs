clipboardText: text
	"Set text currently on the clipboard.  Also export to OS"
	contents _ text.
	self noteRecentClipping: text.
	self primitiveClipboardText: text string