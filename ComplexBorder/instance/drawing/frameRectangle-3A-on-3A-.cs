frameRectangle: aRectangle on: aCanvas
	"Note: This uses BitBlt since it's roughly a factor of two faster for rectangles"
	| w h r |
	self colors ifNil:[^super frameRectangle: aRectangle on: aCanvas].
	w _ self width.
	w isPoint ifTrue:[h _ w y. w _ w x] ifFalse:[h _ w].
	1 to: h do:[:i| "top/bottom"
		r _ (aRectangle topLeft + (i-1)) extent: (aRectangle width - (i-1*2))@1. "top"
		aCanvas fillRectangle: r color: (colors at: i).
		r _ (aRectangle bottomLeft + (i @ (0-i))) extent: (aRectangle width - (i-1*2) - 1)@1. "bottom"
		aCanvas fillRectangle: r color: (colors at: colors size - i + 1).
	].
	1 to: w do:[:i| "left/right"
		r _ (aRectangle topLeft + (i-1)) extent: 1@(aRectangle height - (i-1*2)). "left"
		aCanvas fillRectangle: r color: (colors at: i).
		r _ aRectangle topRight + ((0-i)@i) extent: 1@(aRectangle height - (i-1*2) - 1). "right"
		aCanvas fillRectangle: r color: (colors at: colors size - i + 1).
	].