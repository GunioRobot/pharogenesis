gotoFrame: frame
	"Jump to the given frame"
	self stopPlaying.
	self frameNumber: frame+1.
	^nil