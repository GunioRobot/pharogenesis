testBreak1
	"Checks whether the beginning of a new line starts at the indented position"
	| cb |
	para compositionRectangle: (0@0 extent: para width - 1@100); updateCompositionHeight.
	para clippingRectangle: (0@0 extent: 200@200).
	cb := para characterBlockForIndex: 8.
	self assert: cb top > 0.
	self assert: cb left = 24