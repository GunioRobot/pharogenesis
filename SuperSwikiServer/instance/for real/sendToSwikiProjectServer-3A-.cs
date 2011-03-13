sendToSwikiProjectServer: anArray

	| argsDict answer buildStream |

	buildStream _ WriteStream on: String new.
	anArray do: [ :each | 
		buildStream 
			nextPutAll: each size printString;
			space;
			nextPutAll: each
	].
	(argsDict _ Dictionary new)
		at: 'swikicommands'
		put: {buildStream contents}.
	answer _ HTTPSocket 
		httpPostMultipartBOB: self url
		args: argsDict
		accept: 'application/octet-stream' 
		request: ''.
	^(answer isKindOf: MIMEDocument) ifTrue: [answer content] ifFalse: [answer]
