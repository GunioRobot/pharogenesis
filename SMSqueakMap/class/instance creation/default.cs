default
	"Return the default map, create one if missing."

	"SMSqueakMap default"

	^DefaultMap ifNil: [DefaultMap _ self new]