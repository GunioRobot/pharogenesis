compareToClipboard
	"Check to see if whether the receiver's text is the same as the text currently on the clipboard, and inform the user.  4/29/96 sw"
	| count s |
	s _ self clipboardText string.
	count _ paragraph text string charactersExactlyMatching: s.
	count == (paragraph text string size max: s size) 
		ifTrue:
			[^ self inform: 'Exact match'].

	self selectFrom: 1 to: count