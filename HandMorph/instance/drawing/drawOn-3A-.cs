drawOn: aCanvas
	"Draw the hand itself (i.e., the cursor)."

	temporaryCursor == nil
		ifTrue: [aCanvas paintImage: NormalCursor at: bounds topLeft]
		ifFalse: [aCanvas paintImage: temporaryCursor at: bounds topLeft].
	userInitials size > 0 ifTrue:
		[aCanvas text: userInitials
					at: (self cursorBounds topRight + (0@4))
					font: nil color: color].
