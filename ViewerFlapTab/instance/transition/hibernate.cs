hibernate
	"drop my viewer to save space when writing to the disk."

	referent submorphs do: 
		[:m | (m isKindOf: Viewer) ifTrue: [m delete]]