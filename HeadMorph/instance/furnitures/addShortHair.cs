addShortHair
	| hair |
	hair := CurveMorph
		vertices: {81@3. 101@22. 105@48. 93@65. 76@32. 54@32. 28@35. 11@64. 2@52. 10@15. 45@2}
		color: self randomHairColor
		borderWidth: 1
		borderColor: Color black.
	hair extent: (hair extent * (self width / hair width * 1.15)) rounded.
	hair align: hair center x @ (hair top * 4 + hair bottom // 5) with: self center x @ self top.
	self addMorphFront: hair