addVolumeSlider
	"private - add the volume slider"

	| r |
	volumeSlider _ SimpleSliderMorph new
		color: (Color r: 0.71 g: 0.871 b: 1.0);
		extent: 200@2;
		target: moviePlayer;
		actionSelector: #volume:;
		adjustToValue: 0.5.
	r _ AlignmentMorph newRow
		color: Color transparent;
		layoutInset: 0;
		wrapCentering: #center; cellPositioning: #leftCenter; listCentering: #center;
		hResizing: #shrinkWrap;
		vResizing: #rigid;
		height: 24.
	r addMorphBack: (StringMorph contents: '  soft ' translated).
	r addMorphBack: volumeSlider.
	r addMorphBack: (StringMorph contents: ' loud' translated).
	self addMorphBack: r.
