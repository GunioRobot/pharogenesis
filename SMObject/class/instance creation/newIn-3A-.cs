newIn: aMap
	"Create a new object in a given map with an UUID to ensure unique identity."

	^(self new) map: aMap id: UUID new