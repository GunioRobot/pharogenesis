drawOn: aCanvas

	(project ~~ nil and: [project thumbnail ~~ lastProjectThumbnail]) ifTrue:
			["scale thumbnail to fit my bounds"
			(WarpBlt toForm: image)
				sourceForm: project thumbnail;
				cellSize: 2;  "installs a colormap"
				combinationRule: Form over;
				copyQuad: (project thumbnail boundingBox) innerCorners
				toRect: (0@0 extent: image extent).
			lastProjectThumbnail _ project thumbnail.
			image borderWidth: 1].
	super drawOn: aCanvas.
