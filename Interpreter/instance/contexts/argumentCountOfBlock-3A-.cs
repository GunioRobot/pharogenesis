argumentCountOfBlock: blockPointer

	| localArgCount |
	localArgCount _ self fetchPointer: BlockArgumentCountIndex ofObject: blockPointer.
	^self checkedIntegerValueOf: localArgCount