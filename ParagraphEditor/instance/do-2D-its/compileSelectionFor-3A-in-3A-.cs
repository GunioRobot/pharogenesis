compileSelectionFor: anObject in: evalContext

	| methodNode method |
	methodNode _ [Compiler new
		compileNoPattern: self selectionAsStream
		in: anObject class
		context: evalContext
		notifying: self
		ifFail: [^nil]]
			on: OutOfScopeNotification
			do: [:ex | ex resume: true].
	method _ methodNode generate: #(0 0 0 0).
	^method copyWithTempNames: methodNode tempNames