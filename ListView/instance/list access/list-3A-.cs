list: anArray 
	"Set the list of items the receiver displays to be anArray."

	| arrayCopy i |
	isEmpty _ anArray isEmpty.
	arrayCopy _ Array new: (anArray size + 2).
	arrayCopy at: 1 put: topDelimiter.
	arrayCopy at: arrayCopy size put: bottomDelimiter.
	i _ 2.
	anArray do: [:el | arrayCopy at: i put: el. i _ i+1].
	"arrayCopy _ Array with: topDelimiter with: bottomDelimiter.
	arrayCopy _ arrayCopy copyReplaceFrom: 2 to: 1 with: anArray."
	arrayCopy _ arrayCopy copyWithout: nil.
	list _ ListParagraph withArray: arrayCopy lineSpacing: lineSpacing.
	selection _ 0.
	self positionList