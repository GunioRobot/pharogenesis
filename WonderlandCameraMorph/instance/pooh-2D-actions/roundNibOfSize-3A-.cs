roundNibOfSize: extent
	"Create a round nib for antialiased painting"
	| largeForm smallForm warp colorForm |
	CachedNibs ifNil:[CachedNibs _ Dictionary new].
	colorForm _ CachedNibs at: extent ifAbsent:[nil].
	colorForm ifNotNil:[^colorForm].
	largeForm _ Form extent: extent * 4 depth: 32.
	largeForm getCanvas fillOval: largeForm boundingBox color: Color white.
	smallForm _ Form extent: extent depth: 32.
	warp _ WarpBlt toForm: smallForm.
	warp sourceForm: largeForm destRect: smallForm boundingBox.
	warp cellSize: 4. "oh yes"
	warp warpBits.
	largeForm _ nil.
	colorForm _ smallForm asGrayScale.
	CachedNibs at: extent put: colorForm.
	^colorForm