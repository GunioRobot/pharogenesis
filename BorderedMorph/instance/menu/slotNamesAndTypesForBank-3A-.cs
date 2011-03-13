slotNamesAndTypesForBank: aNumber
	"Return an array of part names and part types for use in a viewer on the receiver's costumee; here we only put the costume-specific parts"
	^ aNumber == 2
		ifTrue: 
			[#(
			(color			color		readWrite	getColor				setColor:)
			(borderWidth 		number		readWrite	getBorderWidth	setBorderWidth:)
			(borderColor			color		readWrite	getBorderColor	setBorderColor:)
		"(mouseX			number		readOnly	getMouseX			unused)"
		"(mouseY		number		readOnly	getMouseY			unused)"
)]

		ifFalse:
			[super slotNamesAndTypesForBank: aNumber]
