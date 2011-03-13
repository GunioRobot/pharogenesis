accept: aString 
	| result |
	result := self doItReceiver class evaluatorClass new 
		evaluate: aString readStream
		in: self doItContext
		to: self doItReceiver
		notifying: nil
		ifFail: 
			[ "fix this"
			self changed: #flash.
			^ false ].
	result == #failedDoit ifTrue: [ ^ false ].
	self replaceSelectionValue: result.
	self changed: #contents.
	^ true