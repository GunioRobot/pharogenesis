drawOn: aCanvas
	"Draw this morph only if it has no target."

	target == nil ifTrue: [^ super drawOn: aCanvas].
	Preferences showBoundsInHalo ifTrue:
		[aCanvas frameAndFillRectangle: target boundsInWorld
				fillColor: Color transparent
				borderWidth: 1
				borderColor: Color blue]