fullDrawOn: aCanvas

	(aCanvas isVisible: self fullBounds) ifFalse: [^ self].
	(aCanvas isVisible: bounds) ifTrue: [self drawOn: aCanvas].
	submorphs isEmpty ifFalse: [
		submorphs reverseDo: [:m | m fullDrawOn: aCanvas]].  "draw back-to-front"
