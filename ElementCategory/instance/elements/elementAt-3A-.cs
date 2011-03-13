elementAt: aKey
	"Answer the element at the given key"

	^ elementDictionary at: aKey ifAbsent: [nil]