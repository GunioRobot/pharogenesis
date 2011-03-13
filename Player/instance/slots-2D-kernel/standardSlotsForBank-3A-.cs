standardSlotsForBank: aBank
	"Return an array of slot names and slot info for use in a viewer on the receiver"

"		name		type		r/w			get selector			put selector
		-----------	---------		-----------	---------------------	-------------   "

	aBank = 1 ifTrue: [^ #(
		(heading	number		readWrite	getHeading			setHeading:)
		(x 			number		readWrite	getX					setX:)
		(y			number		readWrite	getY				setY:)
		(colorUnder	color		readOnly	getColorUnder		unused))].

	aBank = 3 ifTrue: [^ #(
		(penDown	boolean		readWrite	getPenDown			setPenDown:)
		(penColor	color		readWrite	getPenColor			setPenColor:)
		(penSize 	number		readWrite	getPenSize			setPenSize:))].

	aBank = 4 ifTrue: [^ #(
		(colorSees	boolean		readOnly	dummy				unused)
		(scaleFactor	number		readWrite	getScaleFactor		setScaleFactor:)
		(width 		number		readWrite	getWidth			setWidth:)
		(height 		number		readWrite	getHeight			setHeight:)
		(left 		number		readWrite	getLeft				setLeft:)
		(right 		number		readWrite	getRight			setRight:)
		(top 		number		readWrite	getTop				setTop:)
		(bottom 		number		readWrite	getBottom			setBottom:)
		)].

	^ #()