downloadStateIn: aScamper
	| doc |
	doc _ sourceUrl retrieveContents.
	(FlashMorphReader on: doc contentStream binary) processFileAsync: self.
	"Wait until the first frame is there"
	[loadedFrames = 0] whileTrue:[(Delay forMilliseconds: 100) wait].
	aScamper invalidateLayout.
	self startPlaying.