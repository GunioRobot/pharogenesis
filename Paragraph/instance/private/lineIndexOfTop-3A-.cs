lineIndexOfTop: top 
	"Answer the line index at a given top y."
	| y line |
	lastLine = 0 ifTrue: [^ 1].
	y _ compositionRectangle top.
	1 to: lastLine do:
		[:i | line _ lines at: i.
		(y _ y + line lineHeight) > top ifTrue: [^ i]].
	^ lastLine
