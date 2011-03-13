downloadState
	| doc |
	doc := sourceUrl retrieveContents.
	(FlashMorphReader on: doc contentStream binary) processFileAsync: self.
	self startPlaying.