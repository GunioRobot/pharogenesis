newHashFor: obj
	"If an object has a hash derived from its value, it will override on the way here.
	This object can use anything as a hash.  Derive one from its oop."

	(self mapAt: obj) = UnassignedOop
		ifTrue: [self halt]
		ifFalse: [^ self mapHashAt: obj]  