initialize

	super initialize.
	borderWidth _ 2.
	orientation _ #vertical.
	soundInput _ SoundInputStream new samplingRate: 22050.
	fft _ FFT new: 512.
	displayType _ 'sonogram'.

	self addButtonRow.
	self addLevelSlider.
	self addMorphBack: self makeLevelMeter.
	self addMorphBack: (Morph new extent: 10@10; color: Color transparent).  "spacer"
	self resetDisplay.  "adds the display morph"
