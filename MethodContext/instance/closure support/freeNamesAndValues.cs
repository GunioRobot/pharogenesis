freeNamesAndValues
	| aStream eval |
	eval := 
	[ :string | 
	self class evaluatorClass new 
		evaluate2: string readStream
		in: self
		to: nil
		notifying: nil
		ifFail: 
			[ "fix this"
			self error: 'bug' ]
		logged: false ].
	aStream := '' writeStream.
	self freeNames doWithIndex: 
		[ :name :index | 
		aStream
			nextPutAll: name;
			nextPut: $:;
			space;
			tab.
		(eval value: name) printOn: aStream.
		aStream cr ].
	^ aStream contents