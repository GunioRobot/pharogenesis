addEars
	| leftEar rightEar |
	leftEar := EllipseMorph new color: self color; extent: self height // 10 @ (self height // 7).
	rightEar := leftEar copy.
	leftEar align: leftEar center with: self left @ self center y.
	rightEar align: rightEar center with: self right @ self center y.
	self addMorphBack: leftEar; addMorphBack: rightEar