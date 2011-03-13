addSpikyHair
	| hair |
	hair := PolygonMorph
		vertices: {83@3. 81@30. 91@27. 111@23. 97@32. 112@37. 99@45. 114@52. 95@53. 55@43. 10@50. 1@40. 14@40. 8@26. 24@37. 15@11. 29@29. 30@16. 36@30. 41@6. 49@31. 54@8. 61@32. 64@1. 70@27}
		color: self randomHairColor
		borderWidth: 1
		borderColor: Color black.
	hair extent: (hair extent * (self width / hair width * 1.15)) rounded.
	hair align: hair center with: self center x @ self top.
	self addMorphFront: hair