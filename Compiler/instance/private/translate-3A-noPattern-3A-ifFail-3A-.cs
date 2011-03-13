translate: aStream noPattern: noPattern ifFail: failBlock
	| tree |
	tree  := 
		self parserClass new
			parse: aStream
			class: class
			category: category
			noPattern: noPattern
			context: context
			notifying: requestor
			ifFail: [^ failBlock value].
	^ tree
