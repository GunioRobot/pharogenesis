artistKeystroke: aCharacter

	list2 do: [ :artist |
		(artist first asLowercase = aCharacter asLowercase) ifTrue: [
			self artist: artist]].