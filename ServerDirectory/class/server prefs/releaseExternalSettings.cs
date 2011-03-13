releaseExternalSettings
	"Release for server configurations"
	"ServerDirectory releaseExternalSettings"

	Preferences externalServerDefsOnly
		ifTrue: [ Servers := Dictionary new]