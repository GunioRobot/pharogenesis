firstShown
	"Return the index of the top item currently visible"
	| trial |
	trial := self findSelection: self insetDisplayBox topLeft.
	^ trial == nil
		ifTrue: [1]
		ifFalse: [trial]