staggerPolicyString
	^ (self valueOfFlag: #reverseWindowStagger)
		ifTrue: ['switch to tiling']
		ifFalse: ['switch to staggering']