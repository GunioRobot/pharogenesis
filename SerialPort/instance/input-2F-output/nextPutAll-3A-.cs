nextPutAll: aStringOrByteArray
	"Send the given bytes out this serial port. The port must be open."

	^ self primWritePort: port
		from: aStringOrByteArray
		startingAt: 1
		count: aStringOrByteArray size.
