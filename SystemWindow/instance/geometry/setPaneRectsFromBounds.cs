setPaneRectsFromBounds
	"Reset proportional specs from actual bounds, eg, after reframing panes"
	| layoutBounds box frame left right top bottom |
	layoutBounds _ self layoutBounds.
	paneMorphs do:[:m|
		frame _ m layoutFrame.
		box _ m bounds.
		frame ifNotNil:[
			left _ box left - layoutBounds left - (frame leftOffset ifNil:[0]).
			right _ box right - layoutBounds left - (frame rightOffset ifNil:[0]).
			top _ box top - layoutBounds top - (frame topOffset ifNil:[0]).
			bottom _ box bottom - layoutBounds top - (frame bottomOffset ifNil:[0]).
			frame leftFraction: (left / layoutBounds width asFloat).
			frame rightFraction: (right / layoutBounds width asFloat).
			frame topFraction: (top / layoutBounds height asFloat).
			frame bottomFraction: (bottom / layoutBounds height asFloat).
		].
	].