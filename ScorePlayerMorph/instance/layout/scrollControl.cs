scrollControl

	| r |
	scrollSlider _ SimpleSliderMorph new
		color: color;
		sliderColor: Color gray;
		extent: 360@2;
		target: scorePlayer;
		actionSelector: #positionInScore:;
		adjustToValue: scorePlayer positionInScore.
	r _ self makeRow
		hResizing: #shrinkWrap;
		vResizing: #rigid;
		height: 24.
	r addMorphBack: (StringMorph contents: 'start ').
	r addMorphBack: scrollSlider.
	r addMorphBack: (StringMorph contents: ' end').
	^ r
