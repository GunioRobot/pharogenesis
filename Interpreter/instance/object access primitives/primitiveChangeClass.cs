primitiveChangeClass
	"Primitive. Change the class of the receiver into the class of the argument given that the format of the receiver matches the format of the argument's class. Fail if receiver or argument are SmallIntegers, or the receiver is an instance of a compact class and the argument isn't, or when the argument's class is compact and the receiver isn't, or when the format of the receiver is different from the format of the argument's class, or when the arguments class is fixed and the receiver's size differs from the size that an instance of the argument's class should have."
	| arg rcvr argClass classHdr sizeHiBits byteSize argFormat rcvrFormat ccIndex |
	arg _ self stackObjectValue: 0.
	rcvr _ self stackObjectValue: 1.
	successFlag ifFalse:[^nil].

	"Get the class we want to convert the receiver into"
	argClass _ self fetchClassOf: arg.

	"Check what the format of the class says"
	classHdr _ self formatOfClass: argClass. "Low 2 bits are 0"

	"Compute the size of instances of the class (used for fixed field classes only)"
	sizeHiBits _ (classHdr bitAnd: 16r60000) >> 9.
	classHdr _ classHdr bitAnd: 16r1FFFF.
	byteSize _ (classHdr bitAnd: SizeMask) + sizeHiBits. "size in bytes -- low 2 bits are 0"

	"Check the receiver's format against that of the class"
	argFormat _ (classHdr >> 8) bitAnd: 16rF.
	rcvrFormat _ self formatOf: rcvr.
	argFormat = rcvrFormat ifFalse:[^self primitiveFail]. "no way"

	"For fixed field classes, the sizes must match.
	Note: byteSize-4 because base header is included in class size."
	argFormat < 2 ifTrue:[(byteSize - 4) = (self byteSizeOf: rcvr) ifFalse:[^self primitiveFail]].

	(self headerType: rcvr) = HeaderTypeShort
		ifTrue:[ "Compact classes. Check if the arg's class is compact and exchange ccIndex"
			ccIndex _ classHdr bitAnd: CompactClassMask.
			ccIndex = 0 ifTrue:[^self primitiveFail]. "class is not compact"
			self longAt: rcvr put:
				(((self longAt: rcvr) bitAnd: CompactClassMask bitInvert32)
					bitOr: ccIndex)]
		ifFalse:["Exchange the class pointer, which could make rcvr a root for argClass"
			self longAt: rcvr-4 put: (argClass bitOr: (self headerType: rcvr)).
			(rcvr < youngStart) ifTrue: [self possibleRootStoreInto: rcvr value: argClass]].

	"Flush cache because rcvr's class has changed"
	self flushMethodCache.

	successFlag ifTrue: [ self pop: 1 ]