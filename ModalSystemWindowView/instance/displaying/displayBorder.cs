displayBorder
	"Display the receiver's border (using the receiver's borderColor)."

	modalBorder ifFalse: [^super displayBorder].

	Display
		border: self displayBox
		widthRectangle: (1@1 corner: 2@2)
		rule: Form over
		fillColor: Color black.
	Display
		border: (self displayBox insetBy: (1@1 corner: 2@2))
		widthRectangle: (4@4 corner: 3@3)
		rule: Form over
		fillColor: (Color r: 16rEA g: 16rEA b: 16rEA).
