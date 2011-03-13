close
	"Close the serial port. Do nothing if the port is not open."

	port ifNotNil: [self primClosePort: port].
	port _ nil.
