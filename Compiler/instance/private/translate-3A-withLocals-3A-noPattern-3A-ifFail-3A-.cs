translate: aStream withLocals: localDict noPattern: noPattern ifFail: failBlock

	| tree |
	tree _ 
		Parser new
			parse: aStream
			class: class
			noPattern: noPattern
			locals: localDict
			notifying: requestor
			ifFail: [^failBlock value].
	^tree