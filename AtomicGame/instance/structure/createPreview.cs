createPreview
	| extra |
	currentMap buildLayoutForPreview: self.
	extra _ currentMap previewNeededSize x.
	bounds _ bounds extendBy: extra @ 0.
	self changed