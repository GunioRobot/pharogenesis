fetchClassOf: oop
	| ccIndex |
	self inline: true.
	(self isIntegerObject: oop)
		ifTrue: [ ^ self splObj: ClassInteger ].

	ccIndex _ ((self baseHeader: oop) >> 12) bitAnd: 16r1F.
	ccIndex = 0
		ifTrue: [^ (self classHeader: oop) bitAnd: AllButTypeMask ]
		ifFalse: ["look up compact class"
				^ self fetchPointer: ccIndex - 1
					ofObject: (self fetchPointer: CompactClasses ofObject: specialObjectsOop)
		].
