passwordFor: serverDir
	"Returned the password from one of many sources.  OK if send in a nil arg."

	| sp msg |
	cache ifNotNil: [^ cache].
	sequence ifNotNil: [
		(sp _ self serverPasswords) ifNotNil: [
			sequence <= sp size ifTrue: [^ sp at: sequence]]].
	msg _ serverDir isRemoteDirectory
		ifTrue: [serverDir moniker]
		ifFalse: ['this directory'].
	(serverDir user = 'anonymous') & (serverDir typeWithDefault == #ftp) ifTrue: [
			^ cache _ FillInTheBlank request: 'Please let this anonymous ftp\server know your email address.\This is the polite thing to do.' withCRs
			initialAnswer: 'yourName@company.com'].

	^ cache _ FillInTheBlank requestPassword: 'Password for ', serverDir user, ' at ', msg, ':'.
		"Diff between empty string and abort?"