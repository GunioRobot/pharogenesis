forwardVideo: aNumber forStream: aStream
	| newLocation |

	self hasVideo ifFalse: [^self].
	newLocation := (((self currentVideoFrameForStream: aStream) + aNumber) min: (self videoFrames: aStream)) max: 0.
	self currentVideoFrameForStream: aStream put: newLocation.
