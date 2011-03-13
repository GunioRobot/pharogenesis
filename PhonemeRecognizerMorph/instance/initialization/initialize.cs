initialize

	| r |
	super initialize.
	borderWidth _ 2.
	self listDirection: #topToBottom.
	soundInput _ SoundInputStream new samplingRate: 22050.
	phonemeRecords _ OrderedCollection new.
	silentPhoneme _ PhonemeRecord new initialize name: '...'.
	currentPhoneme _ silentPhoneme.  "the PhonemeRecord of the current match"
	self addTitle.
	self addButtonRows.
	self addLevelSlider.
	r _ AlignmentMorph newRow vResizing: #shrinkWrap.
	r addMorphBack: self makeLevelMeter.
	self addMorphBack: r.
	self addPhonemeDisplay.
	self extent: 10@10.  "make minimum size"
