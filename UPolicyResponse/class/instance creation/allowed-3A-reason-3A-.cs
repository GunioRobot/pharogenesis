allowed: aBoolean  reason: aReason
	^self basicNew
		allowed: aBoolean;
		reason: (aReason ifNil: ['no reason given']);
		yourself