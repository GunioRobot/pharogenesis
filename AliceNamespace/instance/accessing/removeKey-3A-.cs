removeKey: theKey
	"Remove the key from the namespace"

	myDictionary removeKey: theKey ifAbsent: [].
