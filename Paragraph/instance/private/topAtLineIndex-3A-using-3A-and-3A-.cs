topAtLineIndex: lineIndex using: otherLines and: otherLastLine
	"Answer the top y of given line."
	| y |
	y _ compositionRectangle top.
	otherLastLine = 0 ifTrue: [^ y].
	1 to: (lineIndex-1 min: otherLastLine) do:
		[:i | y _ y + (otherLines at: i) lineHeight].
	^ y
