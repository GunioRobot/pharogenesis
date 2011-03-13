newContents: stringOrText fromCard: aCard
	"Accept new text contents."
	| newText setter |

	newText := stringOrText asText.
	text = newText ifTrue: [^ self].  "No substantive change"

	text ifNotNil: [
		text embeddedMorphs do: [ :m | m delete ] ].

	text := newText.

	"add all morphs off the visible region; they'll be moved into the right place when they become visible.  (this can make the scrollable area too large, though)"
	stringOrText asText embeddedMorphs do: [ :m | 
		self addMorph: m. 
		m position: (-1000@0)].

	self releaseParagraph.  "update the paragraph cache"
	self paragraph.  "re-instantiate to set bounds"

	self holdsSeparateDataForEachInstance
		ifTrue:
			[setter := self valueOfProperty: #setterSelector.
			setter ifNotNil:
				[aCard perform: setter with: newText]].

	self world ifNotNil:
		[self world startSteppingSubmorphsOf: self ].
