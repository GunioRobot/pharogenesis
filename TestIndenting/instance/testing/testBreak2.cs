testBreak2
	"When an indented line is broken at a space, the character block must still lie in the line crossing the right margin."
	| cb |
	para compositionRectangle: (0@0 extent: para width - 24 // 2 + 24@100); updateCompositionHeight.
	para clippingRectangle: (0@0 extent: 200@200).
	cb := para characterBlockForIndex: 7.
	self assert: cb top = 0.
	self assert: cb left >= 24