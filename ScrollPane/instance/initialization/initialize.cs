initialize
	
	"initialize the state of the receiver"
	super initialize.
	""
	self initializePreferences.
	hasFocus _ false.
	self initializeScrollBars.
	""
	self extent: self defaultExtent.
	self hideOrShowScrollBars.


