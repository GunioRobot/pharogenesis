do: aBlock
	"evaluate aBlock with each character in the set"

	Character allCharacters do: [ :c |
		(self includes: c) ifTrue: [ aBlock value: c ] ]
