id2: idString
	"Add further clue id for acrostic puzzles."

	| idMorph |
	idString ifNotNil:
		[idMorph _ StringMorph contents: idString font: IDFont.
		idMorph align: idMorph bounds topRight with: self bounds topRight + (-1@-1).
		self addMorph: idMorph].

