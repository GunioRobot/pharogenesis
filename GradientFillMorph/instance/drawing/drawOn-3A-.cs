drawOn: aCanvas
	"Note that this could run about 4 times faster if we got hold of
	the canvas's port and just sent it copyBits with new coords and color"
 	| r colors step |
	super drawOn: aCanvas.
	r _ self innerBounds intersect: aCanvas clipRect.
	colors _ self colorArrayForDepth: aCanvas depth.
	step _ self stepSize.
	gradientDirection = #vertical
		ifTrue:
		[r top to: r bottom-1 by: step do:
			[:y | aCanvas fillRectangle: (r left @ y corner: r right @ (y+step min: r bottom))
					color: (colors at: y - bounds top //step+1)]]
		ifFalse:
		[r left to: r right-1 by: step do:
			[:x | aCanvas fillRectangle: (x @ r top corner: (x+step min: r right) @ r bottom)
					color: (colors at: x - bounds left //step+1)]]