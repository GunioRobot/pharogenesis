drawOn: aCanvas 
	| newBound |
	newBound _ self bounds.
	"draws a basic shape of the atom"
	newBound _ self drawAtom: aCanvas bound: newBound.
	"Special behavior for small devices"
	mapStyle
		isSmallScreen ifFalse: [newBound _ self drawBright: aCanvas bound: newBound.
			mapStyle isPreview
				ifTrue: [self drawTitle: aCanvas]].
	"draw the seleccion mark"
	self drawActivation: aCanvas