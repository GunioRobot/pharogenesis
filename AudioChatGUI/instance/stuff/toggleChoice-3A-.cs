toggleChoice: aSymbol

	aSymbol == #playOnArrival ifTrue: [
		^PlayOnArrival _ self class playOnArrival not
	].
	aSymbol == #transmitWhileRecording ifTrue: [
		transmitWhileRecording _ self transmitWhileRecording not.
		self changeTalkButtonLabel.
		^transmitWhileRecording
	].
	aSymbol == #handsFreeTalking ifTrue: [
		handsFreeTalking _ self handsFreeTalking not.
		self changeTalkButtonLabel.
		^handsFreeTalking
	].


