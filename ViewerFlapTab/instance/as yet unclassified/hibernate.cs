hibernate
	| ut |
	"drop my viewer to save space when writing to the disk."

	ut _ self world valueOfProperty: #universalTiles ifAbsent: [false].
	referent submorphs do: 
		[:m | (m isKindOf: Viewer) ifTrue: [ut ifTrue: [m delete]]].
