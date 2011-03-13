addCornerGrips
	self
		addMorphBack: (TopLeftGripMorph new target: self).
	self
		addMorphBack: (TopRightGripMorph new target: self).
	self
		addMorphBack: (BottomLeftGripMorph new target: self).
	self
		addMorphBack: (BottomRightGripMorph new target: self)