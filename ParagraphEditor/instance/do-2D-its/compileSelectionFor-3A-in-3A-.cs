compileSelectionFor: anObject in: evalContext

	| methodNode method |
	methodNode := [Compiler new
		compileNoPattern: self selectionAsStream
		in: anObject class
		context: evalContext
		notifying: self
		ifFail: [^nil]]
			on: OutOfScopeNotification
			do: [:ex | ex resume: true].
	method := methodNode generate: #(0 0 0 0).
	^method copyWithTempsFromMethodNode: methodNode