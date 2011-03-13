drawOn: aCanvas
	| userPic |
	"Draw the hand itself (i.e., the cursor)."

	temporaryCursor == nil
		ifTrue: [aCanvas paintImage: NormalCursor at: bounds topLeft]
		ifFalse: [aCanvas paintImage: temporaryCursor at: bounds topLeft].
	self hasUserInformation ifTrue: [
		aCanvas 
			text: userInitials
			at: (self cursorBounds topRight + (0@4))
			font: nil
			color: color.
		(userPic _ self userPicture) ifNotNil: [
			aCanvas paintImage: userPic at: (self cursorBounds topRight + (0@24))
		].
	].
