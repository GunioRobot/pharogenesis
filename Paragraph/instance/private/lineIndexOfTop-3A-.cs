lineIndexOfTop: top 
	"Answer the line index at a given top y."
	| y line |
	lastLine = 0 ifTrue: [^ 1].
	y := compositionRectangle top.
	1 to: lastLine do:
		[:i | line := lines at: i.
		(y := y + line lineHeight) > top ifTrue: [^ i]].
	^ lastLine
