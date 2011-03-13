lineAt: indexInteger put: aTextLineInterval 
	"Store a line, track last, and grow lines if necessary."
	indexInteger > lastLine ifTrue: [lastLine := indexInteger].
	lastLine > lines size ifTrue: [lines := lines , (Array new: lines size)].
	^lines at: indexInteger put: aTextLineInterval