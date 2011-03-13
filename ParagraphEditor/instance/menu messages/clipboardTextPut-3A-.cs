clipboardTextPut: text
	"Set text currently on the clipboard.  Also export to Mac"

	CurrentSelection _ text.
	Smalltalk clipboardText: CurrentSelection string