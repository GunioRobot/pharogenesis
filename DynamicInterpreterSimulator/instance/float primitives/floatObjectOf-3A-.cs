floatObjectOf: float
	| result sign exponent mantissa mantSize long0 long1 |
true ifTrue: [
	"No conversion needed in Apple ST"
	long0 _ float at: 1.
	long1 _ float at: 2.

] ifFalse: ["Following code useful when porting to different formats"
	((float at: 1) = 0 and: [(float at: 2) = 0])
		ifTrue: [long0 _ 0. long1 _ 0]
		ifFalse: 
	["Read from the PPS 32-bit format"
	sign _ ((float at: 1) bitAnd: 16r8000) bitShift: -15.				"1-bit sign"
	exponent _ (((float at: 1) bitShift: -7) bitAnd: 16rFF) - 16r80. 		"8-bit expt"
	mantissa _ (((float at: 1) bitAnd: 16r7F) bitShift: 16) + (float at: 2).	"23 bit mantissa"
	mantSize _ 23.

	"Convert to first 32 bits of 64-bit IEEE format"
	long0 _ (sign bitShift: 31)										"1-bit sign"
			+ (exponent + 16r400 bitShift: 20)						"11-bit expt"
			+ ((mantissa bitShift: 20 - mantSize) bitAnd: 16rFFFFF).	"20 bit mantissa"
	].
 ]. "end of porting code"

	result _ self instantiateClass: (self splObj: ClassFloat) indexableSize: 2.
	self storeWord: 0 ofObject: result withValue: long0.
	self storeWord: 1 ofObject: result withValue: long1.
	^ result