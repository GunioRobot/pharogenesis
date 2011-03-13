valueWithRequestor: aRequestor 
	"To do later: make the fillInTheBlank display more informative captions.
	Include the description of the service, and maybe record steps"

	^ self numArgs isZero 
		ifTrue: [self value]
		ifFalse: [self value: aRequestor]