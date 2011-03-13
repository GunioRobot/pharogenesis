freeNamesAndValues

	| aStream eval |
	eval _ [:string |
		self class evaluatorClass new
			evaluate2: (ReadStream on: string)
			in: self
			to: nil
			notifying: nil	"fix this"
			ifFail: [self error: 'bug']
			logged: false].

	aStream _ '' writeStream.
	self freeNames doWithIndex: [:name :index |
		aStream nextPutAll: name; nextPut: $:; space; tab.
		(eval value: name) printOn: aStream.
		aStream cr].
	^ aStream contents