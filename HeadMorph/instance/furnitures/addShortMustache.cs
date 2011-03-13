addShortMustache
	| mustache |
	mustache := CurveMorph
		vertices: {29@1. 54@14. 30@11. 1@15}
		color: self randomHairColor
		borderWidth: 1
		borderColor: Color black.
	mustache extent: (mustache extent * (self width / mustache width * 0.5)) rounded.
	mustache align: mustache center with: self face mustachePosition.
	self addMorphFront: mustache