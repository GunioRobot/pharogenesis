initialize
	"EventSensor initialize"
	self initializeEventSensorConstants.

	EventPollFrequency _ 20.
	"Note: The above is important. Most systems will not
	notify the VM about the occurance of events asynchronously.
	Therefore, we have to go check for ourselves every now and then."