removeKey: theKey ifAbsent: failBlock
	"Remove the key from the namespace. If the key isn't there, run the code in the fail block."

	myDictionary removeKey: theKey ifAbsent: failBlock.
