drawBoundsOn: aCanvas
	"Shows where line boundaries are"
	container ifNil:
			[aCanvas frameRectangle: bounds color: Color green]
		ifNotNil:
			[self paragraph lines do:
				[:line | aCanvas frameRectangle: line rectangle color: Color green]].
