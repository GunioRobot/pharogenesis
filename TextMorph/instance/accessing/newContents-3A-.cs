newContents: stringOrText 
	"Accept new text contents."
	| newText embeddedMorphs |
	newText _ stringOrText asText.
	text = newText ifTrue: [^ self].
	"No substantive change"

	text ifNotNil: [(embeddedMorphs _ text embeddedMorphs)
			ifNotNil: 
				[self removeAllMorphsIn: embeddedMorphs.
				embeddedMorphs do: [:m | m delete]]].

	text _ newText.

	"add all morphs off the visible region; they'll be moved into the right 
	place when they become visible. (this can make the scrollable area too 
	large, though)"
	stringOrText asText embeddedMorphs do: 
		[:m | 
		self addMorph: m.
		m position: -1000 @ 0].
	self releaseParagraph.
	"update the paragraph cache"
	self paragraph.
	"re-instantiate to set bounds"
	self world ifNotNil: [self world startSteppingSubmorphsOf: self]