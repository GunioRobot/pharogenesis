default
	"Return the default map, create one if missing."

	"SMSqueakMap default"

	^DefaultMap ifNil: [DefaultMap := self new]