initialize
	"initialize the state of the receiver"
	super initialize.
	""
	
	self extent: 400 @ 300.
	showMeasureLines _ true.
	showBeatLines _ false.
	self timeSignature: 4 over: 4.
	self clipSubmorphs: true