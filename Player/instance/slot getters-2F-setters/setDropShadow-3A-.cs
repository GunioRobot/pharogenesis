setDropShadow: aValue
	"Setter for costume's dropShadow"

	| aMorph |
	(aMorph _ costume renderedMorph) hasDropShadow ~~ aValue ifTrue: [aMorph toggleDropShadow]