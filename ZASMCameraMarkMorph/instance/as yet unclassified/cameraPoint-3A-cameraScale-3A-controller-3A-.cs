cameraPoint: aPoint cameraScale: aNumber controller: aController

	self setProperty: #cameraPoint toValue: aPoint.
	self setProperty: #cameraScale toValue: aNumber.
	self setProperty: #cameraController toValue: aController.
	self addMorph: (
		StringMorph contents: aPoint printString,'  ',(aNumber roundTo: 0.001) printString
	) lock.