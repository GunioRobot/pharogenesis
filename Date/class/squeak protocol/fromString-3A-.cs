fromString: aString
	"Answer an instance of created from a string with format dd.mm.yyyy."

	^ self readFrom: aString readStream.
