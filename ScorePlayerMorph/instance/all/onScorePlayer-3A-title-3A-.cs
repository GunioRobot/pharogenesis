onScorePlayer: aScorePlayer title: scoreName

	| divider col |
	scorePlayer _ aScorePlayer reset.
	trackInstNames _ Array new: scorePlayer score tracks size withAll: 'oboe1'.
	divider _ LayoutMorph new
		extent: 10@1;
		borderWidth: 1;
		inset: 0;
		borderColor: #raised;
		color: color;
		hResizing: #spaceFill;
		vResizing: #rigid.

	self removeAllMorphs.
	false ifTrue: [  "title"
		scoreName size > 0 ifTrue: [
			self addMorphBack:
				(StringMorph
					contents: scoreName
					font: (TextStyle default fontOfSize: 20))]].
	self addMorphBack: self makeControls.
	self addMorphBack: self rateControl.
	col _ LayoutMorph newColumn color: color; inset: 0.
	self addMorphBack: col.
	1 to: scorePlayer trackCount do: [:trackIndex |
		col addMorphBack: divider fullCopy.
		col addMorphBack: (self trackControlsFor: trackIndex)].
