on: aProject

	project _ aProject.
	lastProjectThumbnail _ nil.
	project thumbnail
		ifNil: [self extent: 80@100]
		ifNotNil: [self extent: project thumbnail extent].
