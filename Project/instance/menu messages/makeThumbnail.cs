makeThumbnail
	"Make a thumbnail image of this project from the Display."

	viewSize ifNotNil: [
		thumbnail _ Form extent: viewSize depth: Display depth.
		(WarpBlt toForm: thumbnail)
			sourceForm: Display;
			cellSize: 2;  "installs a colormap"
			combinationRule: Form over;
			copyQuad: (Display boundingBox) innerCorners
			toRect: (0@0 extent: viewSize)].
