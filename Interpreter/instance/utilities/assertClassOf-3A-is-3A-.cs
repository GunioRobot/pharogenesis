assertClassOf: oop is: classOop
	"Succeed if the given (non-integer) object is an instance of the given class. Fail if the object is an integer."

	| ccIndex cl |
	self inline: true.
	(self isIntegerObject: oop)
		ifTrue: [ successFlag _ false. ^ nil ].

	ccIndex _ ((self baseHeader: oop) >> 12) bitAnd: 16r1F.
	ccIndex = 0
		ifTrue: [ cl _ ((self classHeader: oop) bitAnd: AllButTypeMask) ]
		ifFalse: [
			"look up compact class"
			cl _ (self fetchPointer: (ccIndex - 1)
					ofObject: (self fetchPointer: CompactClasses ofObject: specialObjectsOop))].

	self success: cl = classOop.
