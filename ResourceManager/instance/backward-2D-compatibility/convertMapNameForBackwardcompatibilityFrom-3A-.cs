convertMapNameForBackwardcompatibilityFrom: aString 
	(SmalltalkImage current platformName = 'Mac OS' 
		and: ['10*' match: SmalltalkImage current osVersion]) 
			ifTrue: [^aString convertFromWithConverter: ShiftJISTextConverter new].
	^aString convertFromSystemString