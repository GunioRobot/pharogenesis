render: anObject
	| assoc |
	assoc _ Association key: anObject value: maxVtx.
	objects addLast: assoc.
	anObject renderOn: self.
	(objects removeLast == assoc) ifFalse:[^self error:'Object stack is confused'].
	assoc value rasterPosZ > 2.0 ifFalse:[pickList add: assoc].