displayOn: aDisplayMedium at: aDisplayPoint clippingBox: clipRectangle rule: ruleInteger fillColor: aForm
	"This is the real display message, but it doesn't get used until the new
	display protocol is installed."
	| targetBox patternBox bb |
	(patternForm isKindOf: Form) ifFalse:
		[^ aDisplayMedium fill: clipRectangle rule: ruleInteger fillColor: patternForm].

	"Do it iteratively"
	targetBox _ aDisplayMedium boundingBox intersect: clipRectangle.
	patternBox _ patternForm boundingBox.
	bb _ BitBlt destForm: aDisplayMedium sourceForm: patternForm fillColor: aForm
		combinationRule: ruleInteger destOrigin: 0@0 sourceOrigin: 0@0
		extent: patternBox extent clipRect: clipRectangle.
	bb colorMap:
		(patternForm colormapIfNeededForDepth: aDisplayMedium depth).
	(targetBox left truncateTo: patternBox width)
		to: targetBox right - 1 by: patternBox width do:
		[:x |
		(targetBox top truncateTo: patternBox height)
			to: targetBox bottom - 1 by: patternBox height do:
			[:y |
			bb destOrigin: x@y; copyBits]]