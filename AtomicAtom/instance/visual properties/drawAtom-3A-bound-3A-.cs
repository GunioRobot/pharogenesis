drawAtom: aCanvas bound: aBound 
	"Draw the shadow and the body"
	| newBound |
	mapStyle isSmallScreen
		ifTrue: [newBound _ aBound insetBy: 2]
		ifFalse: [newBound _ aBound insetBy: 4.
			"shadow"
			aCanvas
				fillOval: (newBound translateBy: 2)
				color: Color veryVeryLightGray].
	"draws the links"
	self drawLinks: aCanvas.
	"real color..."
	aCanvas fillOval: newBound color: self defaultColor.
	^ newBound