releaseWithId: anIdString 
	"Look up a specific package release of mine. Return nil if missing.
	They are few so we just do a #select:."

	| anId |
	anId _ UUID fromString: anIdString.
	releases detect: [:rel | rel id = anId ].
	^nil