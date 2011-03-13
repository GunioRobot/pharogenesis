text: aStringOrBlock button: buttonString description: aString action: aBlock condition: cBlock
	"use when id can be generated"
	^ self 
		id: nil 
		text: aStringOrBlock 
		button: buttonString 
		description: aString 
		action: aBlock
		condition: cBlock