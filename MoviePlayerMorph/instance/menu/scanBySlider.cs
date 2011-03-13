scanBySlider
	| scrollSlider handle |
	scrollSlider _ SimpleSliderMorph new extent: 150@10;
		color: color; sliderColor: Color gray;
		target: self; actionSelector: #goToRelativePosition:;
		adjustToValue: self relativePosition.
	(handle _ scrollSlider firstSubmorph) on: #mouseUp send: #delete to: scrollSlider.
	scrollSlider align: handle center with: self activeHand position.
	self world addMorph: scrollSlider.
	self activeHand targetOffset: (handle width // 2) @ 0.
	self activeHand newMouseFocus: handle