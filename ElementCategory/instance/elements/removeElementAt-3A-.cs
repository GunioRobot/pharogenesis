removeElementAt: aKey
	"Remove the element at the given key"

	elementDictionary removeKey: aKey ifAbsent: [^ self].
	keysInOrder remove: aKey ifAbsent: []