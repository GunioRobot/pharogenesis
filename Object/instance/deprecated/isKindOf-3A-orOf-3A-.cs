isKindOf: aClass orOf: anotherClass
	"Answer whether the class, aClass, is a superclass or class of the receiver."

	self deprecated: 'Use isKindOf: or, even better, don''t.'.
	^ (self isKindOf: aClass) or: [self isKindOf: anotherClass]