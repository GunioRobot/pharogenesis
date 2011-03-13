checkForMoreKeyboard
	"Quick check for more keyboard activity -- Allows, eg, many characters
	to be accumulated into a single replacement during type-in."
	self flag: #arNote. "Will not work if we don't examine event queue in Sensor"
	^nil