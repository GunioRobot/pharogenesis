readEvalPrint
	| line okToRevert |
	okToRevert := true.
	[#('quit' 'exit' 'done' ) includes: (line := self request: '>')]
		whileFalse:
		[line = 'revert'
		ifTrue: [okToRevert
			ifTrue: [Utilities revertLastMethodSubmission.
					self cr; show: 'reverted: ' , Utilities mostRecentlySubmittedMessage.
					okToRevert := false]
			ifFalse: [self cr; show: 'Only one level of revert currently supported']]
		ifFalse: [self cr; show: ([Compiler evaluate: line] ifError: [:err :ex | err])]]