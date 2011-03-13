onScorePlayer: aScorePlayer title: scoreName
	| divider col r |
	scorePlayer _ aScorePlayer.
	scorePlayer ifNotNil:
		[scorePlayer  reset.
		instrumentSelector _ Array new: scorePlayer score tracks size].
	divider _ AlignmentMorph new
		extent: 10@1;
		borderWidth: 1;
		layoutInset: 0;
		borderColor: #raised;
		color: color;
		hResizing: #spaceFill;
		vResizing: #rigid.

	self removeAllMorphs.
	self addMorphBack: self makeControls.
	scorePlayer ifNil: [^ self].

	r _ self makeRow
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap.
	r addMorphBack: self rateControl;
		addMorphBack: (Morph newBounds: (0@0 extent: 20@0) color: Color transparent);
		addMorphBack: self volumeControl.
	self addMorphBack: r.
	self addMorphBack: self scrollControl.

	col _ AlignmentMorph newColumn color: color; layoutInset: 0.
	self addMorphBack: col.
	1 to: scorePlayer trackCount do: [:trackIndex |
		col addMorphBack: divider fullCopy.
		col addMorphBack: (self trackControlsFor: trackIndex)].

	LastMIDIPort ifNotNil: [
		"use the most recently set MIDI port"
		scorePlayer openMIDIPort: LastMIDIPort].
