bottomAtLineIndex: lineIndex 
	"Answer the bottom y of given line."
	| y |
	y := compositionRectangle top.
	lastLine = 0 ifTrue: [^ y + textStyle lineGrid].
	1 to: (lineIndex min: lastLine) do:
		[:i | y := y + (lines at: i) lineHeight].
	^ y
