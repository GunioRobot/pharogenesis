addAfroHair
	| hair |
	hair := CurveMorph
		vertices: {115@4. 144@20. 166@79. 132@131. 116@93. 88@85. 54@94. 40@134. 2@79. 31@16. 79@1}
		color: self randomHairColor
		borderWidth: 1
		borderColor: Color black.
	hair extent: (hair extent * (self width / hair width * 1.9)) rounded.
	hair align: hair center with: self center x @ self top.
	self addMorphFront: hair