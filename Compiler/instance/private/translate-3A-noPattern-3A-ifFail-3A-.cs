translate: aStream noPattern: noPattern ifFail: failBlock

	| tree |
	tree _ 
		Parser new
			parse: aStream
			class: class
			noPattern: noPattern
			context: context
			notifying: requestor
			ifFail: [^failBlock value].
	^tree