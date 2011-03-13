slotNamesAndTypesForBank: aNumber
	"Return an array of part names and part types for use in a viewer on the receiver's costumee; here we only put the costume-specific parts.  Generic Morph has none, but check other implementors"

	^ aNumber == 2
		ifTrue:
			[#(	(color			color		readWrite	getColor				setColor:)
				"(mouseX		number		readOnly	getMouseX			unused)"
				"(mouseY		number		readOnly	getMouseY			unused)"
)]
		ifFalse:
			[Array new]