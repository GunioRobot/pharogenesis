drawOn: aCanvas 
	"Draw this morph only if it has no target."

	target isNil ifTrue: [^super drawOn: aCanvas].
	Preferences showBoundsInHalo 
		ifTrue: 
			[aCanvas 
				frameAndFillRectangle: self bounds
				fillColor: Color transparent
				borderWidth: 1
				borderColor: Color blue]