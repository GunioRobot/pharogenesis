releaseWithAutomaticVersionString: aVersionString
	"Look up a specific package release of mine. Return nil if missing.
	They are few so we just do a #select:."

	^self releaseWithAutomaticVersion: aVersionString asVersion