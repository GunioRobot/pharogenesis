drawOn: aCanvas
	"Draw the hand itself (i.e., the cursor)."

	UseHardwareCursor ifFalse: [
		temporaryCursor == nil
			ifTrue: [aCanvas image: NormalCursor at: self position]
			ifFalse: [aCanvas image: temporaryCursor at: self position]].
	userInitials size > 0 ifTrue:
		[aCanvas text: userInitials at: (self position + (16@4)) font: nil color: color].
