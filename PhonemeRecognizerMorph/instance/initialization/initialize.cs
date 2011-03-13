initialize
	"PhonemeRecognizerMorph new openInWorld."
	
	| r |
	super initialize.

	soundInput := SoundInputStream new samplingRate: 22050.
	recognizer := PhonemeRecognizer new.

	borderWidth := 2.
	self listDirection: #topToBottom.
	"Morph must be told how to resize before adding submorphs, not after."
	self hResizing: #shrinkWrap; vResizing: #shrinkWrap.
	self addTitle.
	self addButtonRows.
	self addLevelSlider.
	r := AlignmentMorph newRow vResizing: #shrinkWrap.
	r addMorphBack: self makeLevelMeter.
	self addMorphBack: r.
	self addPhonemeDisplay.