image: aForm at: aPoint sourceRect: sourceRect rule: rule
	| warp dstRect srcQuad dstOffset center |
	(self ifNoTransformWithIn: sourceRect) & false
		ifTrue:[^super image: aForm at: aPoint sourceRect: sourceRect rule: rule].
	dstRect _ (transform localBoundsToGlobal: (aForm boundingBox translateBy: aPoint)).
	dstOffset _ 0@0. "dstRect origin."
	"dstRect _ 0@0 corner: dstRect extent."
	center _ 0@0."transform globalPointToLocal: dstRect origin."
	srcQuad _ transform globalPointsToLocal: (dstRect innerCorners).
	srcQuad _ srcQuad collect:[:pt| pt - aPoint].
	warp _ (WarpBlt current toForm: form)
			sourceForm: aForm;
			cellSize: 2;  "installs a new colormap if cellSize > 1"
			combinationRule: Form over.
	warp copyQuad: srcQuad toRect: (dstRect translateBy: dstOffset).

	self frameRectangle: (aForm boundingBox translateBy: aPoint) color: Color green.

	"... TODO ... create a bitmap fill style from the form and use it for a simple rectangle."