initialize
	super initialize.
	self color: self randomSkinColor.
	self face: FaceMorph new.
	self extent: self face extent * (1.5 @ 1.7).
	self face align: self face center with: self center + (0 @ self height // 10).
	self addRandomFurnitures.
	queue _ SharedQueue new