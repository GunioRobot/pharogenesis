tileRows
	"Return an collection of arrays of Tiles in which each array is one line of tiles."

	| rows r |
	rows _ OrderedCollection new.
	firstTileRow to: submorphs size do: [:i |
		r _ submorphs at: i.
		r submorphCount > 0 ifTrue: [rows addLast: r submorphs]].
	^ rows
