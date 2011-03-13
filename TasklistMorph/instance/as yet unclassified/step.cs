step
	"Check the sensor for the command key to see if we're done."

	(Preferences keepTasklistOpen not and: [Sensor commandKeyPressed not])
		ifTrue: [self done]