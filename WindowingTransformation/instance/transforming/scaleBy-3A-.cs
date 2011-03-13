scaleBy: aScale 
	"Answer a WindowingTransformation with the scale and translation of 
	the receiver both scaled by aScale."

	| checkedScale newScale newTranslation |
	aScale == nil
		ifTrue: 
			[newScale := scale.
			newTranslation := translation]
		ifFalse: 
			[checkedScale := self checkScale: aScale.
			scale == nil
				ifTrue: [newScale := checkedScale]
				ifFalse: [newScale := scale * checkedScale].
			newTranslation := checkedScale * translation].
	^WindowingTransformation scale: newScale translation: newTranslation