= anObject

	self species == anObject species ifFalse: [^ false].
	^ anObject left = self left
		and: [anObject right = self right
			and: [anObject text = self text
				and: [anObject phonemes = self phonemes]]]