floatValueOf: objectPointer
	| float len long0 long1 sign exponent mantissa mantSize |
	(self isIntegerObject: objectPointer)
		ifTrue: [^ (self integerValueOf: objectPointer) asFloat].
	(self fetchClassOf: objectPointer) = (self splObj: ClassFloat)
		ifFalse: [self success: false.  ^0.0].
	len _ self fetchWordLengthOf: objectPointer.
	(len between: 2 and: 3)
		ifFalse: [self success: false.  ^0.0].

	"FIRST convert image formats to sign/exponent/mantissa"
	len = 2 ifTrue:  
		["Normal 64-bit IEEE format"
		long0 _ self fetchWord: 0 ofObject: objectPointer.
		long1 _ self fetchWord: 1 ofObject: objectPointer.
true ifTrue: [float _ Float new: 2.  "No conversion needed for AST"
			float at: 1 put: long0.
			float at: 2 put: long1.
			^ float].
		long0 = 0 ifTrue: [^ 0.0].
		sign _ (long0 bitAnd: 16r80000000) bitShift: -31.				"1-bit sign"
		exponent _ ((long0 bitShift: -20) bitAnd: 16r7FF) - 16r400.		"11-bit exponent"
		mantissa _ ((long0 bitAnd: 16rFFFFF) bitShift: 32) + long1.		"52-bit mantissa"
		mantSize _ 52]
		ifFalse:  
		["Weird 80-bit Apple format -- will go away soon"
		long0 _ self fetchWord: 0 ofObject: objectPointer.
		long1 _ self fetchWord: 1 ofObject: objectPointer.
		long0 = 0 ifTrue: [^ 0.0].
		sign _ (long0 bitAnd: 16r80000000) bitShift: -31.				"1-bit sign"
		exponent _ ((long0 bitShift: -16) bitAnd: 16r7FFF) - 16r4000. 	"15-bit exponent"
		"Note: drop the (redundant) high bit (16r8000) of mantissa"
		mantissa _ ((long0 bitAnd: 16r7FFF) bitShift: 32) + long1.		"47-bit mantissa"
		mantSize _ 47].

	"THEN convert sign/exponent/mantissa to host format"
	float _ Float new: 2.  "PPSST FP uses 2 16-bit words"
	float at: 1 put: (sign bitShift: 15)							"1-bit sign"
				+ (exponent + 16r80 bitShift: 7)				"8-bit expt"
				+ ((mantissa bitShift: 7 - mantSize) bitAnd: 16r7F).	"7 bits of mantissa"
	float at: 2 put: ((mantissa bitShift: 16 - (mantSize - 7)) bitAnd: 16rFFFF).  "16 more bits of mantissa"
	^ float