fullDrawOn: aCanvas butDoNotDraw: morphNotToDraw

	self == morphNotToDraw ifTrue: [^ self].
	(aCanvas isVisible: self fullBounds) ifFalse: [^ self].
	(aCanvas isVisible: bounds) ifTrue: [self drawOn: aCanvas].
	submorphs isEmpty ifFalse:
		[submorphs reverseDo: [:m |
			m fullDrawOn: aCanvas butDoNotDraw: morphNotToDraw]].
