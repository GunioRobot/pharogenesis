addVoiceControls 

	| levelSlider r meterBox |
	voiceRecorder _ SoundRecorder new
		samplingRate: 11025.0;
		codec: (ADPCMCodec new initializeForBitsPerSample: 4 samplesPerFrame: 0).
.
	levelSlider _ SimpleSliderMorph new
		color: color;
		extent: 100@2;
		target: voiceRecorder;
		actionSelector: #recordLevel:;
		adjustToValue: voiceRecorder recordLevel.
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

	meterBox _ Morph new extent: 102@18; color: Color gray.
	recordMeter _ Morph new extent: 1@16; color: Color yellow.
	recordMeter position: meterBox topLeft + (1@1).
	meterBox addMorph: recordMeter.

	r _ AlignmentMorph newRow vResizing: #shrinkWrap.
	r addMorphBack: meterBox.
	self addMorphBack: r.
