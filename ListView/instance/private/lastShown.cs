lastShown
	"Return the index of the bottom item currently visible"
	| trial bottomMargin |
	bottomMargin _ self insetDisplayBox height \\ list lineGrid.
	trial _ self findSelection: self insetDisplayBox bottomLeft - (0@bottomMargin).
	trial == nil
		ifTrue: [trial _ self findSelection: self insetDisplayBox bottomLeft
					- (0@(list lineGrid+bottomMargin))].
	^ trial == nil
		ifTrue: [list numberOfLines - 2]
		ifFalse: [trial]