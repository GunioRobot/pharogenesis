primitiveScanCharacters
	"Invoke the scanCharacters primitive."

	| rcvr start stop string rightX stopArray displayFlag |
	rcvr _ self stackValue: 6.
	start _ self stackIntegerValue: 5.
	stop _ self stackIntegerValue: 4.
	string _ self stackValue: 3.
	rightX _ self stackIntegerValue: 2.
	stopArray _ self stackValue: 1.
	displayFlag _ self booleanValueOf: (self stackValue: 0).
	successFlag ifFalse: [^ nil].
	self success: (self loadScannerFrom: rcvr
					start: start stop: stop string: string rightX: rightX
					stopArray: stopArray displayFlag: displayFlag).
	successFlag
		ifTrue: [self scanCharacters].
	successFlag
		ifTrue: [
			displayFlag ifTrue: [self showDisplayBits].
			self pop: 7.
			self push: self stopReason].