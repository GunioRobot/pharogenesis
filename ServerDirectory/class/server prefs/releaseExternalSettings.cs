releaseExternalSettings
	"Release for server configurations"
	"ServerDirectory releaseExternalSettings"

	Preferences externalServerDefsOnly
		ifTrue: [
			self resetLocalProjectDirectories.
			Servers _ Dictionary new]