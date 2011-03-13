cacheBits
	| oldLabelState |
	CacheBits ifFalse: [^ self uncacheBits].
	(oldLabelState _ isLabelComplemented) ifTrue: [ self deEmphasize ].
	self cacheBitsAsIs.
	(isLabelComplemented _ oldLabelState) ifTrue: [ self emphasize ].
