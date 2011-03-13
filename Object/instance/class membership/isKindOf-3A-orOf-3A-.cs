isKindOf: aClass orOf: anotherClass
	"Answer whether either of the classes, aClass or anotherClass,, is a superclass or class of the receiver.  A convenience; could be somewhat optimized"
	^ (self isKindOf: aClass) or: [self isKindOf: anotherClass]