objectWithId: anIdString
	"Look up a categorizable object. Return nil if missing."

	^objects at: (UUID fromString: anIdString) ifAbsent: [nil]