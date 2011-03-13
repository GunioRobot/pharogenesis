artistKeystroke: aCharacter

	self artistList doWithIndex: [:artist :i |
		(artist first asLowercase = aCharacter asLowercase) ifTrue: [
			self artist: i]].
