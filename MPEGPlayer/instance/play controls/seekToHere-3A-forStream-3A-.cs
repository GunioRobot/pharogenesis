seekToHere: aPercentage forStream: aStream
	"Alternate method is to seek all video/audio for stream to a certain percentage using the primitive, but I think your mpeg must have timecodes! otherwise endless loop"
	self external seekPercentage: aPercentage