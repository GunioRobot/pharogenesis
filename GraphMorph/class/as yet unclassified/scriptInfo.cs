scriptInfo
	"Answer a list of arrays which characterize new etoy script commands understood by this kind of morph -- in addition to those already defined by superclasses.  This is used only for initializing an effectively global structure."

	^ #	((command clear)
		(command loadSineWave)
		(command loadSound: sound)
		(command reverse)
		(command play))
