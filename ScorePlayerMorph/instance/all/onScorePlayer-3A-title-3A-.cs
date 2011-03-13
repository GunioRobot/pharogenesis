onScorePlayer: aScorePlayer title: scoreName

	| divider col |
	scorePlayer _ aScorePlayer reset.
	self addMorph: self makeControls.
	instrumentSelector _ Array new: scorePlayer score tracks size.
	divider _ AlignmentMorph new
		extent: 10@1;
		borderWidth: 1;
		inset: 0;
		borderColor: #raised;
		color: color;
		hResizing: #spaceFill;
		vResizing: #rigid.

	self removeAllMorphs.
	self addMorphBack: self makeControls.
	self addMorphBack: self rateControl.
	col _ AlignmentMorph newColumn color: color; inset: 0.
	self addMorphBack: col.
	1 to: scorePlayer trackCount do: [:trackIndex |
		col addMorphBack: divider fullCopy.
		col addMorphBack: (self trackControlsFor: trackIndex)].
