VerifyStyle: parameter
	"If the parameter is a valid style (BlockContext that takes 2 parameters) this method returns true, otherwise it throws an exception"

	| result |

	[ result _ ((parameter numArgs) = 2) ]
		ifError: [ :msg :rcvr |
					self error: 'your style was not a block that takes 2 parameters and returns a value between 0 and 1.' ].

	(result) ifTrue: [ ^ true ]
			ifFalse: [ self error: 'your style function did not take exactly 2 parameters. ' ].