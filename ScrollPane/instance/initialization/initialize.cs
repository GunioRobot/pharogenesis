initialize
	
	"initialize the state of the receiver"
	super initialize.
	""
	self initializePreferences.
	hasFocus _ false.
	self initializeScrollBars.
	""
	self extent: 150 @ 120.
	self hideOrShowScrollBars.


