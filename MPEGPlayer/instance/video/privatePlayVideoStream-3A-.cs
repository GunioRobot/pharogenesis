privatePlayVideoStream: aStream
	
	| location |
	self hasVideo ifFalse: 
		[self timeCheck: 0@0.
		^self].
	self checkForm: aStream.
	self frameRate: (self videoFrameRate: aStream).
	location _ self currentVideoFrameForStream: aStream.
	self clockBiasForStream: aStream 
		put: (1/self frameRate*location*1000) asInteger.
	self videoLoop: aStream.
	self timeCheck: ((Time millisecondClockValue + (self clockBiasForStream: aStream) - (self startTimeForStream: aStream))/1000.0) @ ((self videoFrames: aStream) / self frameRate).
	self videoPlayerProcess: nil