isCircular: aRelease
	"Answer if there is a reference that goes back
	to the release of this configuration."

	"This is the base case"
	aRelease == object ifTrue: [^ true].
	
	aRelease configurations do: [:conf |
		conf requiredReleases do: [:rel |
			(self isCircular: rel) ifTrue: [^ true]]].
	^false