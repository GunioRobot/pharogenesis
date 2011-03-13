addHighHat
	| hat |
	hat := CurveMorph
		vertices: {70@3. 98@11. 94@46. 112@50. 96@58. 53@50. 18@61. 2@58. 24@48. 30@6. 47@6}
		color: Color random
		borderWidth: 1
		borderColor: Color black.
	hat extent: (hat extent * (self width / hat width * 4 / 3)) rounded.
	hat align: hat center x @ hat bottom with: self center x @ self face top.
	self addMorphFront: hat