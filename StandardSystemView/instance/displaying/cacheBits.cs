cacheBits
	| oldLabelState |
	CacheBits ifFalse: [^ self uncacheBits].
	(oldLabelState := isLabelComplemented) ifTrue: [ self deEmphasize ].
	self cacheBitsAsIs.
	(isLabelComplemented := oldLabelState) ifTrue: [ self emphasize ].
