setNoImageContents
	"set up our morphic contents in case image download/decoding failed"
	| stringMorph outlineMorph extent |
	altText isEmptyOrNil
		ifTrue: [ self extent: 0@0. "don't display anything..." ^self ].

	stringMorph _ StringMorph new.
	stringMorph contents: altText.
	stringMorph position: self position+(2@2).
	self addMorph: stringMorph.

	outlineMorph _ RectangleMorph new.
	outlineMorph borderWidth: 1.
	outlineMorph color: Color transparent.
	outlineMorph position: self position.

	"figure out how big to make the box"
	extent _ defaultExtent ifNil: [ 0 @ 0 ].
	stringMorph width + 4 > extent x ifTrue: [
		extent _ (stringMorph width + 4) @ extent y ].
	stringMorph height + 4 > extent y ifTrue: [
		extent _ extent x @ (stringMorph height + 4) ].
	outlineMorph extent: extent.
	self addMorph: outlineMorph.

	self extent: outlineMorph extent
