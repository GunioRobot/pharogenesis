releaseWithAutomaticVersion: aVersion
	"Look up a specific package release of mine. Return nil if missing.
	They are few so we just do a #select:."

	^releases detect: [:rel | rel automaticVersion = aVersion ] ifNone: [nil]