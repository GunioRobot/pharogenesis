addMorph: aMorph
	"add a morph to the output"
	| savedAttributes |
	self addChar: Character space.

	savedAttributes _ outputStream currentAttributes.
	outputStream currentAttributes: (savedAttributes copyWith: (TextAnchor new anchoredMorph: aMorph)).
	self addChar: $*.
	outputStream currentAttributes: savedAttributes.

	self addChar: Character space.

	morphsToEmbed add: aMorph.