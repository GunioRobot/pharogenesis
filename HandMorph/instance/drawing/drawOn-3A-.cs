drawOn: aCanvas
	"Draw the hand itself (i.e., the cursor)."

	temporaryCursor == nil
		ifTrue: [aCanvas image: NormalCursor at: bounds topLeft]
		ifFalse: [aCanvas image: temporaryCursor at: bounds topLeft].
	userInitials size > 0 ifTrue:
		[aCanvas text: userInitials at: (self position + (16@4)) font: nil color: color].
