argumentCountOfBlock: blockPointer

	| argCount |
	argCount _ self fetchPointer: BlockArgumentCountIndex
							ofObject: blockPointer.
	(self isIntegerObject: argCount)
		ifTrue: [ ^ self integerValueOf: argCount ]
		ifFalse: [ self primitiveFail. ^0 ].