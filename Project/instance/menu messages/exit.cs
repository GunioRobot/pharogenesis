exit
	"Leave the current project and return to the project
	in which this one was created."

	self isTopProject ifTrue: [^ PopUpMenu notify: 'Can''t exit the top project'].

	"Cache a thumbnail image for the parent view."
	viewSize ifNotNil:
		[thumbnail _ Form extent: viewSize depth: Display depth.
		(WarpBlt toForm: thumbnail)
			sourceForm: Display;
			cellSize: 2;    "installs a colormap"
			combinationRule: Form over;
			copyQuad: (Display boundingBox) innerCorners
			toRect: (0@0 extent: viewSize)].

	activeProcess _ nil.
	parentProject enter.
