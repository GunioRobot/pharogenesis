initialize: aPath

	(MPEGFile isFileValidMPEG: aPath) ifFalse: [^nil].
	external _ MPEGFile openFile: aPath.
	self playerProcessPriority: Processor userSchedulingPriority.
	self lastDelay: 10.
	volume _ 1.0.
	errorForSoundStart _ 500.
	semaphoreForSound _ Semaphore new.
	self startTime: (Array new: self totalVideoStreams).
	self clockBias: (Array new: self totalVideoStreams withAll: 0).