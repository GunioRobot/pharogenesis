topAtLineIndex: lineIndex 
	"Answer the top y of given line."
	| y |
	y _ compositionRectangle top.
	lastLine = 0 ifTrue: [lineIndex > 0 ifTrue: [^ y + textStyle lineGrid]. ^ y].
	1 to: (lineIndex-1 min: lastLine) do:
		[:i | y _ y + (lines at: i) lineHeight].
	^ y
