shouldNotBeRedefined
	"Return true if the receiver should not be redefined.
	The assumption is that compact classes,
	classes in Smalltalk specialObjects and 
	Behaviors should not be redefined"

	^(self environment compactClassesArray includes: self)
		or:[(self environment specialObjectsArray includes: self)
			or:[self isKindOf: self]]