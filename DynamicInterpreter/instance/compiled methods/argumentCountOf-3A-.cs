argumentCountOf: methodPointer
	^ ((self headerOf: methodPointer) >> 25) bitAnd: 16r1F