superclass: aClass 
	"Change the receiver's superclass to be aClass."
	"Note: Do not use 'aClass isKindOf: Behavior' here
		in case we recompile from Behavior itself."
	(aClass == nil or: [aClass isBehavior])
		ifTrue: [superclass _ aClass.
				Object flushCache]
		ifFalse: [self error: 'superclass must be a class-describing object']