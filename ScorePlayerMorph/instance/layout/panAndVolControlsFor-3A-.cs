panAndVolControlsFor: trackIndex

	| volSlider panSlider c r middleLine pianoRollColor |
	pianoRollColor _ (Color wheel: scorePlayer score tracks size) at: trackIndex.
	volSlider _ SimpleSliderMorph new
		color: color;
		sliderColor: pianoRollColor;
		extent: 101@2;
		target: scorePlayer;
		arguments: (Array with: trackIndex);
		actionSelector: #volumeForTrack:put:;
		minVal: 0.0;
		maxVal: 1.0;
		adjustToValue: (scorePlayer volumeForTrack: trackIndex).
	panSlider _ volSlider fullCopy
		actionSelector: #panForTrack:put:;
		minVal: 0.0;
		maxVal: 1.0;		
		adjustToValue: (scorePlayer panForTrack: trackIndex).
	c _ AlignmentMorph newColumn
		color: color;
		layoutInset: 0;
		wrapCentering: #center; cellPositioning: #topCenter;
		hResizing: #spaceFill;
		vResizing: #shrinkWrap.
	middleLine _ Morph new  "center indicator for pan slider"
		color: (Color r: 0.4 g: 0.4 b: 0.4);
		extent: 1@(panSlider height - 4);
		position: panSlider center x@(panSlider top + 2).
	panSlider addMorphBack: middleLine.
	r _ self makeRow.
	r addMorphBack: (StringMorph contents: '0').
	r addMorphBack: volSlider.
	r addMorphBack: (StringMorph contents: '10').
	c addMorphBack: r.
	r _ self makeRow.
	r addMorphBack: (StringMorph contents: 'L').
	r addMorphBack: panSlider.
	r addMorphBack: (StringMorph contents: 'R').
	c addMorphBack: r.
	^ c
