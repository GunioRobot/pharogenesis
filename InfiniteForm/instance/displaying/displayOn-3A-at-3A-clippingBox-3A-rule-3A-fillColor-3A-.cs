displayOn: aDisplayMedium at: aDisplayPoint clippingBox: clipRectangle rule: ruleInteger fillColor: aForm
	"This is the real display message, but it doesn't get used until the new
	display protocol is installed."
	| targetBox patternBox |
	(patternForm class == Pattern)
		ifTrue:
			["Use patternForm as a mask for BitBlt"
			aDisplayMedium fill: clipRectangle 
				rule: ruleInteger fillColor: patternForm.
			^ self].
	(patternForm isKindOf: Form)
		ifFalse:
			["A Color-like thing.  Use patternForm as a mask for BitBlt"
			aDisplayMedium fill: clipRectangle 
				rule: ruleInteger fillColor: patternForm]
		ifTrue:
			["Do it iteratively"
			targetBox _ aDisplayMedium boundingBox intersect: clipRectangle.
			patternBox _ patternForm boundingBox.
			(targetBox left truncateTo: patternBox width)
				to: targetBox right - 1 by: patternBox width do:
				[:x |
				(targetBox top truncateTo: patternBox height)
					to: targetBox bottom - 1 by: patternBox height do:
					[:y |
					patternForm displayOn: aDisplayMedium
						at: x @ y
						clippingBox: clipRectangle
						rule: ruleInteger
						fillColor: aForm]]]