startAudioPlayerProcess: aStream
	self audioPlayerProcess: ([self privatePlayAudioStream: aStream] forkAt: Processor userInterruptPriority)