paneColor
	Display depth > 2 ifTrue:
		[model ifNotNil: [
			model isInMemory ifTrue: [
				^ Color colorFrom: model defaultBackgroundColor]].
		paneMorphs isEmptyOrNil ifFalse: [^ paneMorphs first color]].
	^ Color white