testRun

	| case |
	case := TestTest selector: #setRun.
	case run.
	self assert: case hasSetup.
	self assert: case hasRun.