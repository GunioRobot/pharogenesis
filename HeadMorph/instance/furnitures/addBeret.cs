addBeret
	| beret pompon |
	beret := CurveMorph
		vertices: {66@1. 90@14. 106@22. 114@35. 98@43. 55@35. 20@46. 2@38. 8@23. 23@13. 39@7}
		color: Color random
		borderWidth: 1
		borderColor: Color black.
	beret extent: (beret extent * (self width / beret width * 4 / 3)) rounded.
	beret align: beret center x @ beret bottom with: self center x @ self face top.
	pompon := EllipseMorph new color: beret color; borderWidth: 1; borderColor: Color black; extent: beret height // 2.
	pompon align: pompon center with: beret center x @ beret top.
	beret addMorphFront: pompon.
	self addMorphFront: beret