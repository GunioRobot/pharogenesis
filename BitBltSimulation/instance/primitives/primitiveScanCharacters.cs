primitiveScanCharacters
	"Invoke the scanCharacters primitive."
	| rcvr start stop string rightX stopArray displayFlag |
	self export: true.
	rcvr _ interpreterProxy stackValue: 6.
	start _ interpreterProxy stackIntegerValue: 5.
	stop _ interpreterProxy stackIntegerValue: 4.
	string _ interpreterProxy stackValue: 3.
	rightX _ interpreterProxy stackIntegerValue: 2.
	stopArray _ interpreterProxy stackValue: 1.
	displayFlag _ interpreterProxy booleanValueOf: (interpreterProxy stackValue: 0).
	interpreterProxy failed ifTrue: [^ nil].
	(self loadScannerFrom: rcvr
			start: start stop: stop string: string rightX: rightX
			stopArray: stopArray displayFlag: displayFlag)
		ifFalse:[^interpreterProxy primitiveFail].
	interpreterProxy failed
		ifFalse: [self scanCharacters].
	interpreterProxy failed
		ifFalse: [
			displayFlag ifTrue: [self showDisplayBits].
			interpreterProxy pop: 7.
			interpreterProxy push: self stopReason].