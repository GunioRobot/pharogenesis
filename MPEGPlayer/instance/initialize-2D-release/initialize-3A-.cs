initialize: aPath

	self halt.
	self isBuffer ifTrue: 
		[external := MPEGFile openBuffer: buffer]
	 ifFalse: 
		[(MPEGFile isFileValidMPEG: aPath) ifFalse: [^nil].
		external := MPEGFile openFile: aPath.].
	self playerProcessPriority: Processor userSchedulingPriority.
	self lastDelay: 10.
	volume := 1.0.
	errorForSoundStart := 500.
	semaphoreForSound := Semaphore new.
	self startTime: (Array new: self totalVideoStreams).
	self clockBias: (Array new: self totalVideoStreams withAll: 0).