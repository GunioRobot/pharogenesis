colorAt: aPoint put: aColor
	"Store a Color into the pixel at coordinate aPoint.  6/20/96 tk"

	^ (BitBlt bitPokerToForm: self)
		pixelAt: aPoint
		put: (aColor pixelValueForDepth: depth)
"
[Sensor anyButtonPressed] whileFalse:
	[Display colorAt: Sensor cursorPoint put: Color red]
"