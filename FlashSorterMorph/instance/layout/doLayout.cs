doLayout
	"Do the layout of the child morphs"
	| x y maxHeight w |
	w _ self bounds width.
	x _ 0.
	y _ 0.
	maxHeight _ 0.
	submorphs do:[:m|
		x + m bounds width > w ifTrue:[
			"Wrap the guy on the next line"
			x _ 0.
			y _ y + maxHeight.
			maxHeight _ 0].
		m position: x@y.
		x _ x + m bounds width.
		maxHeight _ maxHeight max: m bounds height].
