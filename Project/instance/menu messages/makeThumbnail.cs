makeThumbnail
	"Make a thumbnail image of this project from the Display."

	world isMorph ifTrue: [world displayWorldSafely]. "clean pending damage"
	viewSize ifNil: [viewSize _ Display extent // 8].
	thumbnail _ Form extent: viewSize depth: Display depth.
	(WarpBlt current toForm: thumbnail)
			sourceForm: Display;
			cellSize: 2;  "installs a colormap"
			combinationRule: Form over;
			copyQuad: (Display boundingBox) innerCorners
			toRect: (0@0 extent: viewSize).
	InternalThreadNavigationMorph cacheThumbnailFor: self.
	^thumbnail
