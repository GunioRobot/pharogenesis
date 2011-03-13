acceptDroppingMorph: aMorph event: evt
	| item |
	dropItemSelector ifNil:[^self].
	item := aMorph passenger.
	model perform: dropItemSelector with: item with: potentialDropRow.
	self resetPotentialDropRow.
	evt hand releaseMouseFocus: self.
	Cursor normal show.
