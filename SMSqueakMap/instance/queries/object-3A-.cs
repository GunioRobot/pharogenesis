object: aUUID
	"Look up a categorizable object. Return nil if missing."

	^objects at: aUUID ifAbsent: [nil]