clipboardText
	"Return text currently on the clipboard.  If it is different from the
	Mac clipboard, then use the latter, since it must be more recent"
	| s |
	s _ Smalltalk clipboardText.
	s = CurrentSelection string
		ifTrue: [^ CurrentSelection]
		ifFalse: [^ s asText]