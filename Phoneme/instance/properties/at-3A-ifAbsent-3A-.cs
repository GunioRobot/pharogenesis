at: anObject ifAbsent: aBlock
	properties isNil ifFalse: [^ properties at: anObject ifAbsent: aBlock].
	^ aBlock value