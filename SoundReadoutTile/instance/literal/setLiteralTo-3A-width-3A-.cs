setLiteralTo: anObject width: w
	"Set the literal and width of the tile as indicated"

	| soundChoices index |
	soundChoices _ self soundChoices.
	index _ soundChoices indexOf: anObject.
	self setLiteral: (soundChoices atWrap: index)