addWhiteHat
	| stage1 stage2 |
	stage1 := CurveMorph
		vertices: {18@1. 93@18. 91@45. 8@40}
		color: (Color r: 1.0 g: 0.968 b: 0.935)
		borderWidth: 1
		borderColor: Color black.
	stage1 extent: (stage1 extent * (self width / stage1 width * 1.20)) rounded.

	stage2 := CurveMorph
		vertices: {27@7. 81@5. 111@34. 11@28}
		color: stage1 color
		borderWidth: 1
		borderColor: Color black.
	stage2 extent: (stage2 extent * (self width / stage2 width * 1.20)) rounded.

	stage1 align: stage1 center with: self center x @ self top.
	stage2 align: stage2 center with: stage1 center x @ stage1 top.

	stage1 addMorphFront: stage2.
	self addMorphFront: stage1