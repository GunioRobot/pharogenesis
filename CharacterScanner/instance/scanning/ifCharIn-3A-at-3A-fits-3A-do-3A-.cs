ifCharIn: str at: i fits: segLen do: fonCharWidthBlock
	"Scan a character of text, tracking font changes, and return true,
	unless the character won't fit or it is off the end of the string."
	"No kerning yet..."
	| ascii char maxAscii |
	i > str size ifTrue: [^ false].
	(runStopIndex == nil or: [i > runStopIndex]) ifTrue:
		[runStopIndex _ i + (text runLengthFor: i) - 1.
		lastIndex _ i.
		self setFont].
	maxAscii _ xTable size-2.
	ascii _ (char _ str at: i) asciiValue min: maxAscii.
	width _ (xTable at: ascii + 2) - (xTable at: ascii + 1).
	width > segLen ifTrue: [^ false].
	fonCharWidthBlock value: font value: char value: width.
	^ true