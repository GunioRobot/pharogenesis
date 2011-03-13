setPaneRectsFromBounds
	"Reset proportional specs from actual bounds, eg, after reframing panes"
	| layoutBounds box frame left right top bottom |
	layoutBounds := self layoutBounds.
	paneMorphs do:[:m|
		frame := m layoutFrame.
		box := m bounds.
		frame ifNotNil:[
			left := box left - layoutBounds left - (frame leftOffset ifNil:[0]).
			right := box right - layoutBounds left - (frame rightOffset ifNil:[0]).
			top := box top - layoutBounds top - (frame topOffset ifNil:[0]).
			bottom := box bottom - layoutBounds top - (frame bottomOffset ifNil:[0]).
			frame leftFraction: (left / layoutBounds width asFloat).
			frame rightFraction: (right / layoutBounds width asFloat).
			frame topFraction: (top / layoutBounds height asFloat).
			frame bottomFraction: (bottom / layoutBounds height asFloat).
		].
	].