httpPostDocument: url args: argsDict
	| argString |
	argString _ argsDict
		ifNotNil: [argString _ HTTPSocket argString: argsDict]
		ifNil: [''].
	^self post: argString url: url , argString ifError: [self halt]