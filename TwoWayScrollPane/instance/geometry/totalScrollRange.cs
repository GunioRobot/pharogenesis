totalScrollRange

	| scrollerSubmorphBounds |
	scrollerSubmorphBounds _ scroller submorphBounds encompass: 0@0.
	^ 
	(scrollerSubmorphBounds width - bounds width" + 48" max: 0)
						@
	(scrollerSubmorphBounds height - bounds height" + 18" max: 0)

