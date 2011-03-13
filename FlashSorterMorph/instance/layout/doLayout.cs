doLayout
	"Do the layout of the child morphs"
	| x y maxHeight w |
	w := self bounds width.
	x := 0.
	y := 0.
	maxHeight := 0.
	submorphs do:[:m|
		x + m bounds width > w ifTrue:[
			"Wrap the guy on the next line"
			x := 0.
			y := y + maxHeight.
			maxHeight := 0].
		m position: x@y.
		x := x + m bounds width.
		maxHeight := maxHeight max: m bounds height].
