playAudioStreamWaitTilDone: aStream

	self hasAudio ifFalse: [^self].
	self setupStream: aStream.
	self privatePlayAudioStream: aStream.