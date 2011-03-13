argumentCountOfBlock: blockPointer

	| localArgCount |
	localArgCount _ self fetchPointer: BlockArgumentCountIndex
							ofObject: blockPointer.
	(self isIntegerObject: localArgCount)
		ifTrue: [ ^ self integerValueOf: localArgCount ]
		ifFalse: [ self primitiveFail. ^0 ].