initialize: size

	references _ IdentityDictionary new: size.
	uniClasses _ IdentityDictionary new.	"UniClass -> new UniClass"
	self isItTimeToCheckVariables ifTrue: [self checkVariables].
