existsFailedCallIn: aMethodRef 
	^ (self existsCompiledCallIn: aMethodRef)
		and: [self blockSelectFailedCall value: aMethodRef]