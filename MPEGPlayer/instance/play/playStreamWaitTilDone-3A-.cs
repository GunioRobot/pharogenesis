playStreamWaitTilDone: aStream
	self noSound: self hasAudio not.
	self privatePlayVideoStream: aStream.