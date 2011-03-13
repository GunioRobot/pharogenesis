platformSpecificStartup
	"Do platform-specific startup. This is a hook for starting up a default Squeak image on an Acorn, whose BitBlt expects Forms to have little-endian byte ordering."

	FormsAreLittleEndian ifNil: [FormsAreLittleEndian _ false].
	FormsAreLittleEndian ifTrue: [^ self].  "already converted"

	Form withAllSubclasses do: [:c |
		c allInstancesDo: [:f |
			"skip the Display, since it will be redrawn anyway"
			f == Display ifFalse: [self byteReverseForm: f]]].

	FormsAreLittleEndian _ true.
