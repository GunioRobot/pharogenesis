allTestSelectors
	DoNotRunLongTestCases ifFalse: [
		^super testSelectors].
	^#().