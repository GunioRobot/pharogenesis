VerifyZeroArgumentBlock: parameter
	"Return true if the parameter is a zero argument block, otherwise throw an exception"

	((parameter class) = BlockContext)
		ifTrue: [ ((parameter numArgs) = 0)
						ifTrue: [ ^ true ]
						ifFalse: [ self error: ' the block can not require arguments.' ]
				]
		ifFalse: [ self error: ' you need to supply a block that does not require arguments.' ].
