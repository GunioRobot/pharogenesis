privateWarp: aForm transform: aTransform at: extraOffset sourceRect: sourceRect cellSize: cellSize
	"Warp the given using the appropriate transform and offset."
	| globalRect sourceQuad warp tfm |
	tfm _ aTransform.
	globalRect _ tfm localBoundsToGlobal: sourceRect.
	sourceQuad _ (tfm sourceQuadFor: globalRect) collect:[:p| p - sourceRect topLeft].
	extraOffset ifNotNil:[globalRect _ globalRect translateBy: extraOffset].
     warp _ (WarpBlt current toForm: port destForm)
                combinationRule: Form paint;
                sourceQuad: sourceQuad destRect: globalRect;
                clipRect: port clipRect.
	warp cellSize: cellSize.
	warp sourceForm: aForm.
	warp warpBits