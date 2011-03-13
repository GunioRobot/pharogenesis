send

	| null rawSound aSampledSound |

	mytargetip isEmpty ifTrue: [
		^self inform: 'You must connect with someone first.'.
	].
	rawSound _ myrecorder recorder recordedSound ifNil: [^self].
	aSampledSound _ rawSound asSampledSound.
"Smalltalk at: #Q3 put: {rawSound. rawSound asSampledSound. aCompressedSound}."
	self transmitWhileRecording ifTrue: [
		self sendOneOfMany: rawSound asSampledSound.
		queueForMultipleSends ifNotNil: [queueForMultipleSends nextPut: nil].
		queueForMultipleSends _ nil.
		^self
	].

	null _ String with: 0 asCharacter.
	EToyPeerToPeer new 
		sendSomeData: {
			EToyIncomingMessage typeAudioChat,null. 
			Preferences defaultAuthorName,null.
			aSampledSound originalSamplingRate asInteger printString,null.
			(mycodec compressSound: aSampledSound) channels first.
		}
		to: mytargetip
		for: self.

