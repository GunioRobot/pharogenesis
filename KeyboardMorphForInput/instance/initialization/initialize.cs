initialize
"initialize the state of the receiver"
	super initialize.
""
	buildingChord _ false.
	self addRecordingControls.
	self duration: 4 onOff: true.
	self durMod: #normal onOff: true.
	self articulation: #normal onOff: true.
	insertMode _ false