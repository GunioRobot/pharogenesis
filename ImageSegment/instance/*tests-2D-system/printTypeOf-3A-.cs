printTypeOf: oop
	"oop is a field pointer, which either is an int or a pointer into the seg or into outPointers"
	
	| index |
	(self isIntegerObject: oop) ifTrue: [ ^'<int>' , (oop >> 1) asString ].
	^((oop bitAnd: 16r80000000) = 0)
		ifTrue: [
			index := oop bitShift: -2.
			((segment at: index) bitAnd: 3) = 2 ifTrue: [ '<free block!>' ].
			self classNameAt: index ]
		ifFalse: [ (outPointers at: ((oop bitAnd: 16r7FFFFFFF) bitShift: -2)) class name ]