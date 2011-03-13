list: anArray 
	"Set the list of items the receiver displays to be anArray."
	| arrayCopy i |
	isEmpty := anArray isEmpty.
	arrayCopy := Array new: (anArray size + 2).
	arrayCopy at: 1 put: topDelimiter.
	arrayCopy at: arrayCopy size put: bottomDelimiter.
	i := 2.
	anArray do: [:el | arrayCopy at: i put: el. i := i+1].
	arrayCopy := arrayCopy copyWithout: nil.
	list := ListParagraph withArray: arrayCopy style: self assuredTextStyle.
	selection := 0.
	self positionList.
