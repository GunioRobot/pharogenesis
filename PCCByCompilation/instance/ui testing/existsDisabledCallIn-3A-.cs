existsDisabledCallIn: aMethodRef 
	| src |
	^ (self existsCompiledCallIn: aMethodRef) not
		and: ["higher priority to avoid source file accessing errors"
			[src := aMethodRef sourceString]
				valueAt: self higherPriority.
			self methodSourceContainsDisabledCall: src]