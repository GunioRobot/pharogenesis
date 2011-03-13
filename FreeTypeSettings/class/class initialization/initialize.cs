initialize
	"
	self initialize
	"
	Smalltalk removeFromStartUpList: self.
	Smalltalk addToStartUpList: self . 
	Smalltalk removeFromShutDownList: self.
	Smalltalk addToShutDownList: self.
	self initializePreferences