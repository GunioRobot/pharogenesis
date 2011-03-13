on: aProject

	project _ aProject.
	self addProjectNameMorphFiller.
	lastProjectThumbnail _ nil.
	project thumbnail
		ifNil: [self extent: 100@80]		"more like screen dimensions?"
		ifNotNil: [self extent: project thumbnail extent].
