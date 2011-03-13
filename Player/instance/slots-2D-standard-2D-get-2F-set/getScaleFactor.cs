getScaleFactor

	costume isFlexMorph
		ifTrue: [^ costume scale]
		ifFalse: [^ 1.0].
