lineAt: indexInteger put: aTextLineInterval 
	"Store a line, track last, and grow lines if necessary."
	indexInteger > lastLine ifTrue: [lastLine _ indexInteger].
	lastLine > lines size ifTrue: [lines _ lines , (Array new: lines size)].
	^lines at: indexInteger put: aTextLineInterval