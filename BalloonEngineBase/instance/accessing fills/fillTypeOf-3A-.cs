fillTypeOf: fill
	^((self objectTypeOf: fill) bitAnd: GEPrimitiveFillMask) >> 8