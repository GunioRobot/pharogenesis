slotNamesAndTypesForBank: aBank
	"Return an array of part names and part types for use in a viewer on the receiver's costumee; here we only put the costume-specific parts"

	aBank == 1 ifTrue: [^ Array new].

	aBank == 2 ifTrue: 
	[^ #(

"		name			type		r/w			get selector			put selector
		-----------		---------		-----------	---------------------	-------------   "
		(color			color		readWrite	getColor				setColor:)
		(borderWidth 	number		readWrite	getBorderWidth		setBorderWidth:)
		(borderColor		color		readWrite	getBorderColor		setBorderColor:))].

	aBank == 3 ifTrue: 
	[^ #(

"		name			type		r/w			get selector			put selector
		-----------		---------		-----------	---------------------	-------------   "
		(cursor 			number		readWrite	getCursor			setCursor:)
		(valueAtCursor	player		readOnly	getValueAtCursor	unused)
									"readWrite						setValueAtCursor:"
		"(mouseX			number		readOnly	getMouseX			unused)
		(mouseY		number		readOnly	getMouseY			unused)"
)].

	^ #()