downloadState
	| doc |
	doc _ sourceUrl retrieveContents.
	(FlashMorphReader on: doc contentStream binary) processFileAsync: self.
	self startPlaying.