addRecordLevelSlider

	| levelSlider r |
	levelSlider _ SimpleSliderMorph new
		color: color;
		extent: 100@2;
		target: recorder;
		actionSelector: #recordLevel:;
		adjustToValue: recorder recordLevel.
	r _ AlignmentMorph newRow
		color: color;
		inset: 0;
		centering: #center;
		hResizing: #shrinkWrap;
		vResizing: #rigid;
		height: 24.
	r addMorphBack: (StringMorph contents: '0 ').
	r addMorphBack: levelSlider.
	r addMorphBack: (StringMorph contents: ' 10').
	self addMorphBack: r.
