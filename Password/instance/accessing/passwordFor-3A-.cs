passwordFor: serverDir
	"Returned the password from one of many sources.  OK if send in a nil arg."

	| sp msg |
	cache ifNotNil: [^ cache].
	sequence ifNotNil: [
		(sp _ self serverPasswords) ifNotNil: [
			sequence <= sp size ifTrue: [^ sp at: sequence]]].
	msg _ (serverDir isKindOf: ServerDirectory)
		ifTrue: [serverDir moniker]
		ifFalse: ['this directory'].
	^ cache _ FillInTheBlank request: 'Password for ', msg, ':'.
		"Diff between empty string and abort?"