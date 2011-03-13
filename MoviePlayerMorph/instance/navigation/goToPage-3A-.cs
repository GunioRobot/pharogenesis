goToPage: i
	currentPage ifNil: [self makeMyPage].
	frameNumber := i.
	playDirection := 0.
	self startRunning; step.  "will stop after first step"
	soundTrackMorph ifNotNilDo: [:m | m image fillWhite].
	self stepSoundTrack.
