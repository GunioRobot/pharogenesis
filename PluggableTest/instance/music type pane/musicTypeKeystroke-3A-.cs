musicTypeKeystroke: aCharacter

	list1 do: [ :type |
		(type first asLowercase = aCharacter asLowercase) ifTrue: [
			self musicType: type]].