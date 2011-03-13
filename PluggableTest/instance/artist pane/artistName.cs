artistName
	"Answer the name of the currently selected artist, or nil if no artist is selected."

	| artistsForCurrentType |
	artistsForCurrentType _ self artistList.
	(artistIndex between: 1 and: artistsForCurrentType size)
		ifTrue: [^ artistsForCurrentType at: artistIndex]
		ifFalse: [^ nil].
