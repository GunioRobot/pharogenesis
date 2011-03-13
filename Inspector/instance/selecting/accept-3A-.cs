accept: aString

	| result |
	result _ self doItReceiver class evaluatorClass new
				evaluate: (ReadStream on: aString)
				in: self doItContext
				to: self doItReceiver
				notifying: nil	"fix this"
				ifFail:  [^ false].
	result == #failedDoit ifFalse: 
			[contents _ result printString.
			self replaceSelectionValue: result.	"may put contents back"
			self changed: #contents.
			^ true].
	^ false