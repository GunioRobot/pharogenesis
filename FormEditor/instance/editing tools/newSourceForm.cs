newSourceForm
	"Allow the user to define a new source form for the FormEditor. Copying 
	the source form onto the display is the primary graphical operation. 
	Resets the tool to be repeatCopy."
	| dForm interiorPoint interiorColor |

	dForm := Form fromUser: grid.
	"sourceForm must be only 1 bit deep"
	interiorPoint := dForm extent // 2.
	interiorColor := dForm colorAt: interiorPoint.
	form := (dForm makeBWForm: interiorColor) reverse
				findShapeAroundSeedBlock:
					[:f | f pixelValueAt: interiorPoint put: 1].
	form := form trimBordersOfColor: Color white.
	tool := previousTool