assignCollapsePointFor: aSSView
	"Offer up a location along the left edge of the screen for a collapsed SSView.
	Make sure it doesn't overlap any other collapsed frames.
	"
	| grid extent allOthers y putativeFrame free |
	grid _ 24.  "should be mult of 8, since manual move is gridded by 8"
	extent _ aSSView labelDisplayBox extent.
	allOthers _ ScheduledControllers scheduledWindowControllers
				collect: [:aController | aController view collapsedFrame]
				thenSelect: [:rect | rect notNil].
	y _ 0.
	[(y _ y + grid) < (Display height - extent y)]
		whileTrue:
		[putativeFrame _ 0@y extent: extent.
		free _ true.
		allOthers do: [:w | free _ free & (w intersects: putativeFrame) not].
		free ifTrue: [^ putativeFrame topLeft]].
	"If all else fails..."
	^ 0 @ 0