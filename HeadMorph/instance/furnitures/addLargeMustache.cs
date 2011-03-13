addLargeMustache
	| mustache |
	mustache := CurveMorph
		vertices: {48@4. 75@3. 93@15. 48@9. 3@19. 17@5}
		color: self randomHairColor
		borderWidth: 1
		borderColor: Color black.
	mustache extent: (mustache extent * (self width / mustache width)) rounded.
	mustache align: mustache center with: self face mustachePosition.
	self addMorphFront: mustache