checkForBlock: receiver selector: selector arguments: arguments
	selector == #blockCopy: ifTrue:
		[^self checkForBlockCopy: receiver].
	self assert: selector == #closureCopy:copiedValues:.
	^self checkForClosureCopy: receiver arguments: arguments