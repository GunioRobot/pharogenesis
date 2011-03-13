featuresGraph
	"Answer a Form containing a pictorial view of my features vector."

	| labelForm graphHeight barWidth bottom f min max scale x h |
	labelForm := name asParagraph asForm.
	graphHeight := 100.
	barWidth := 5.
	bottom := graphHeight + 2.  "2 pixel border"
	f := Form
		extent: (self features size * barWidth) @ (graphHeight + labelForm height + 5)
		depth: 16.
	f fillWhite: f boundingBox.
	f border: f boundingBox width: 2.

	min := 1.0e30.
	max := -1.0e30.
	features do: [:v |
		v < min ifTrue: [min := v].
		v > max ifTrue: [max := v]].
	scale := (graphHeight - 1) asFloat / (max - min).
	x := 2.
	self features do: [:v |
		h := (scale * (v - min)) asInteger.
		f fill: ((x@(bottom - h)) extent: barWidth@h) fillColor: (Color r: 0.581 g: 0.581 b: 0.0).
		x := x + barWidth].
	f fillBlack: ((0@bottom) extent: (f width@1)).
	labelForm displayOn: f
		at: ((f width - labelForm width) // 2)@bottom
		rule: Form paint.
	^ f
