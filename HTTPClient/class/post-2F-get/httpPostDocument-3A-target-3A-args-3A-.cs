httpPostDocument: url target: target args: argsDict
	| argString stream content |
	^self shouldUsePluginAPI
		ifTrue: [
			argString _ argsDict
				ifNotNil: [argString _ HTTPSocket argString: argsDict]
				ifNil: [''].
			stream _ FileStream post: argString , ' ' target: target url: url , argString ifError: [self error: 'Error in post to ' , url printString].
			stream position: 0.
			content _ stream upToEnd.
			stream close.
			MIMEDocument content: content]
		ifFalse: [HTTPSocket httpPostDocument: url  args: argsDict]