installedVersion
	"Return the version String for the installed version.
	We ask the map. Return nil if this package is not installed."

	^self installedRelease ifNotNilDo: [:r | r smartVersion]