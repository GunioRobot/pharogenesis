volumeControl

	| volumeSlider r |
	volumeSlider _ SimpleSliderMorph new
		color: color;
		sliderColor: Color gray;
		extent: 80@2;
		target: scorePlayer;
		actionSelector: #overallVolume:;
		adjustToValue: scorePlayer overallVolume.
	r _ self makeRow
		hResizing: #shrinkWrap;
		vResizing: #rigid;
		height: 24.
	r addMorphBack: (StringMorph contents: 'soft  ').
	r addMorphBack: volumeSlider.
	r addMorphBack: (StringMorph contents: ' loud').
	^ r
