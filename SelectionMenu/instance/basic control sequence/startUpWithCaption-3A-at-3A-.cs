startUpWithCaption: captionOrNil at: location
	"Overridden to return value returned by manageMarker."

	| index |
	index _ super startUpWithCaption: captionOrNil at: location.
	(selections = nil or: [(index between: 1 and: selections size) not])
		ifTrue: [^ nil].
	^ selections at: index