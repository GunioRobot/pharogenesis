featuresGraph
	"Answer a Form containing a pictorial view of my features vector."

	| labelForm graphHeight barWidth bottom f min max scale x h |
	labelForm _ name asParagraph asForm.
	graphHeight _ 100.
	barWidth _ 5.
	bottom _ graphHeight + 2.  "2 pixel border"
	f _ Form
		extent: (self features size * barWidth) @ (graphHeight + labelForm height + 5)
		depth: 16.
	f fillWhite: f boundingBox.
	f border: f boundingBox width: 2.

	min _ 1.0e30.
	max _ -1.0e30.
	features do: [:v |
		v < min ifTrue: [min _ v].
		v > max ifTrue: [max _ v]].
	scale _ (graphHeight - 1) asFloat / (max - min).
	x _ 2.
	self features do: [:v |
		h _ (scale * (v - min)) asInteger.
		f fill: ((x@(bottom - h)) extent: barWidth@h) fillColor: (Color r: 0.581 g: 0.581 b: 0.0).
		x _ x + barWidth].
	f fillBlack: ((0@bottom) extent: (f width@1)).
	labelForm displayOn: f
		at: ((f width - labelForm width) // 2)@bottom
		rule: Form paint.
	^ f
