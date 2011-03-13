newSourceForm
	"Allow the user to define a new source form for the FormEditor. Copying 
	the source form onto the display is the primary graphical operation. 
	Resets the tool to be repeatCopy."
	| dForm interiorPoint interiorColor |
	dForm _ Form fromUser: grid.
	"sourceForm must be only 1 bit deep"
	interiorPoint _ dForm extent // 2.
	interiorColor _ Color colorFromPixelValue:
		(dForm pixelValueAt: interiorPoint) depth: dForm depth.
	form _ (dForm makeBWForm: interiorColor) reverse
				findShapeAroundSeedBlock:
					[:f | f pixelValueAt: interiorPoint put: 1].
	form _ form trimToPixelValue: 1 orNot: false.
	tool _ previousTool