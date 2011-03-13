text: aStringOrBlock button: buttonString description: aString action: aBlock
	"use when id can be automatically generated"
	^ self id: nil 
		text: aStringOrBlock 
		button: buttonString 
		description: aString 
		action: aBlock 
		condition: [:r | true]