lineIndexForPoint: aPoint
	"Answer the index of the line in which to select the character nearest to aPoint."
	| i |
	aPoint y < lines first top ifTrue: [^ 1].
	aPoint y >= lines last bottom ifTrue: [^ lines size].

	"Find the first line at this y-value"
	i _ lines findFirst: [:line | line bottom > aPoint y].

	"Now find the first line at this x-value"
	[i < lines size and: [(lines at: i+1) top = (lines at: i) top
				and: [aPoint x >= (lines at: i+1) left]]]
		whileTrue: [i _ i + 1].
	^ i