fileInObjectAndCode: aStream
	| trusted |
	trusted _ self positionToSecureContentsOf: aStream.
	trusted ifFalse:[self enterRestrictedMode ifFalse:[
		aStream close.
		^nil]].
	^aStream fileInObjectAndCode