contents: aString notifying: aController
	"Compile the code in aString and notify aController of any errors. If there are no errors, then automatically proceed."

	doitFlag
	ifTrue: [Compiler new evaluate: aString in: nil to: nil
						notifying: aController ifFail: [^ false]]
	ifFalse: [(class compile: aString classified: category
						notifying: aController) ifNil: [^ false]].

	aController hasUnacceptedEdits: false.
	self proceed