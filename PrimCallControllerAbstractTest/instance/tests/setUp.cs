setUp
	super setUp.
	pcc := self classToBeTested new.
	"set failed call"
	(self class >> self failedCallSelector) literals first at: 4 put: -1.
	"set it to false for some very slow tests..."
	doNotMakeSlowTestsFlag := true