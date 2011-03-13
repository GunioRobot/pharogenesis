withId: aUUIDString in: aCollection
	"Return the object with the corresponding id
	and nil if not found."

	| uuid |
	uuid := UUID fromString: aUUIDString.
	^aCollection detect: [:o | o id = uuid ] ifNone: [nil]