addPositionSlider
	"private - add the position slider"

	| r |
	positionSlider _ SimpleSliderMorph new
		color: (Color r: 0.71 g: 0.871 b: 1.0);
		extent: 200@2;
		target: moviePlayer;
		actionSelector: #moviePosition:;
		adjustToValue: 0.
	r _ AlignmentMorph newRow
		color: Color transparent;
		layoutInset: 0;
		wrapCentering: #center; cellPositioning: #leftCenter; listCentering: #center;
		hResizing: #shrinkWrap;
		vResizing: #rigid;
		height: 24.
	r addMorphBack: (StringMorph contents: 'start ' translated).
	r addMorphBack: positionSlider.
	r addMorphBack: (StringMorph contents: ' end' translated).
	self addMorphBack: r.
