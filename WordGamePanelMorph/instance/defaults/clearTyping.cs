clearTyping
	"Clear out all letters entered as a solution."

	letterMorphs do: [:m | (m letter notNil and: [m letter isLetter])
							ifTrue: [m setLetter: Character space]].
	self unhighlight.
