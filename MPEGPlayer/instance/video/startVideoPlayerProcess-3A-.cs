startVideoPlayerProcess: aStream
	self videoPlayerProcess: ([self privatePlayVideoStream: aStream] forkAt: self playerProcessPriority)