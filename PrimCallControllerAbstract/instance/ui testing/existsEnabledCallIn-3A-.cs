existsEnabledCallIn: aMethodRef 
	^ (self existsCompiledCallIn: aMethodRef)
		and: [(aMethodRef compiledMethod literals first at: 4)
				>= 0]