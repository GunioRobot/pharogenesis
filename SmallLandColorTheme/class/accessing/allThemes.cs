allThemes
	"
SmallLandColorTheme allThemes.
	"
	^ self withAllSubclasses
		reject: [:each | each == self]