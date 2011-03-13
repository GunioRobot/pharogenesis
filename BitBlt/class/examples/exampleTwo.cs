exampleTwo
	"This is to test painting with a gray tone. It also tests that the seaming with gray patterns is correct in the microcode. Lets you paint for a while and then automatically stops."
	| f aBitBlt |
	"create a small black Form source as a brush. "
	f _ Form extent: 20 @ 20.
	f fillBlack.
	"create a BitBlt which will OR gray into the display. "
	aBitBlt _ BitBlt
		destForm: Display
		sourceForm: f
		fillColor: Color gray
		combinationRule: Form under
		destOrigin: Sensor cursorPoint
		sourceOrigin: 0 @ 0
		extent: f extent
		clipRect: Display computeBoundingBox.
	"paint the gray Form on the screen for a while. "
	[Sensor anyButtonPressed] whileFalse: 
		[aBitBlt destOrigin: Sensor cursorPoint.
		aBitBlt copyBits]

	"BitBlt exampleTwo"