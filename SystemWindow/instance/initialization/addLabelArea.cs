addLabelArea

	labelArea := (AlignmentMorph newSpacer: Color transparent) vResizing: #shrinkWrap;
			layoutPolicy: ProportionalLayout new.
	self addMorph: labelArea.