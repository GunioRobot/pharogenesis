primitiveFileSetPosition
	| newPosition file sz |
	self var: 'file' declareC: 'SQFile *file'.
	self var: 'newPosition' type: 'squeakFileOffsetType'.
	self export: true.
	(interpreterProxy isIntegerObject: (interpreterProxy stackValue: 0)) ifFalse:
		[sz _ self cCode: 'sizeof(squeakFileOffsetType)'.
		(interpreterProxy byteSizeOf: (interpreterProxy stackValue: 0)) > sz 
			ifTrue: [^interpreterProxy primitiveFail]].
	newPosition _ interpreterProxy positive64BitValueOf: (interpreterProxy stackValue: 0).
	file _ self fileValueOf: (interpreterProxy stackValue: 1).
	interpreterProxy failed ifFalse:[
		self sqFile: file SetPosition: newPosition ].
	interpreterProxy failed ifFalse:[
		interpreterProxy pop: 2 "pop position, file; leave rcvr on stack" ].