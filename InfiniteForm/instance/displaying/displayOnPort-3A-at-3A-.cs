displayOnPort: aPort at: offset

	| targetBox patternBox savedMap top left |
	(patternForm isKindOf: Form) ifFalse: [
		"patternForm is a Pattern or Color; just use it as a mask for BitBlt"
		^ aPort fill: aPort clipRect fillColor: patternForm rule: Form over].

	"do it iteratively"
	targetBox _ aPort clipRect.
	patternBox _ patternForm boundingBox.
	savedMap _ aPort colorMap.
	aPort
		sourceForm: patternForm;
		fillColor: nil;
		combinationRule: Form over;
		sourceRect: (0@0 extent: patternBox extent);
		colorMap: (patternForm colormapIfNeededForDepth: aPort destForm depth).
	top _ (targetBox top truncateTo: patternBox height) - (offset y \\ patternBox height).
	left _  (targetBox left truncateTo: patternBox width) - (offset x \\ patternBox width).
	left to: (targetBox right - 1) by: patternBox width do: [:x |
		top to: (targetBox bottom - 1) by: patternBox height do: [:y |
			aPort
				destOrigin: x@y;
				copyBits]].
	aPort colorMap: savedMap.
