fetchClassOf: oop

	| ccIndex |
	self inline: true.
	(self isIntegerObject: oop)
		ifTrue: [ ^ self splObj: ClassInteger ].

	ccIndex _ (((self baseHeader: oop) >> 12) bitAnd: 16r1F) - 1.
	ccIndex < 0
		ifTrue: [ ^ (self classHeader: oop) bitAnd: AllButTypeMask ]
		ifFalse: [
			"look up compact class"
			^ self fetchPointer: ccIndex
				ofObject: (self fetchPointer: CompactClasses ofObject: specialObjectsOop)
		].
