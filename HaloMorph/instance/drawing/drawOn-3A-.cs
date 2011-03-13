drawOn: aCanvas 
	"Draw this morph only if it has no target."
	target isNil
		ifTrue: [^ super drawOn: aCanvas].
	(Preferences showBoundsInHalo
			and: [target isWorldMorph not])
		ifTrue: [| boundsColor | 
			boundsColor := Preferences menuSelectionColor
						ifNil: [Color blue].
			aCanvas
				frameAndFillRectangle: self bounds
				fillColor: Color transparent
				borderWidth: 2
				borderColor: boundsColor]