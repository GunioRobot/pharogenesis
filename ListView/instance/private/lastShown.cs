lastShown
	"Return the index of the bottom item currently visible"
	| trial bottomMargin |
	bottomMargin := self insetDisplayBox height \\ list lineGrid.
	trial := self findSelection: self insetDisplayBox bottomLeft - (0@bottomMargin).
	trial == nil
		ifTrue: [trial := self findSelection: self insetDisplayBox bottomLeft
					- (0@(list lineGrid+bottomMargin))].
	^ trial == nil
		ifTrue: [list numberOfLines - 2]
		ifFalse: [trial]