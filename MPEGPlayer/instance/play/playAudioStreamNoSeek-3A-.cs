playAudioStreamNoSeek: aStream

	self hasAudio ifFalse: [^self].
	self setupStreamNoSeek: aStream.
	self startAudioPlayerProcess: aStream.