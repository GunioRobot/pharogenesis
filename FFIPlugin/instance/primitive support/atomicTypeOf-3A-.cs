atomicTypeOf: value
	^(value bitAnd: FFIAtomicTypeMask) >> FFIAtomicTypeShift