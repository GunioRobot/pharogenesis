setupObjects
	"Set up the list of objects (e.g., triangle inputs)
	by creating a linked list of objects which is sorted by the initial
	yValue of the tris."
	| lastObj |
	objects _ objects sortBy: [:obj1 :obj2| obj1 bounds origin sortsBefore: obj2 bounds origin].
	lastObj _ nil.
	objects do:[:nextObj|
		nextObj reset.
		nextObj prevObj: lastObj.
		lastObj == nil ifFalse:[lastObj nextObj: nextObj].
		lastObj _ nextObj.
	].
	lastObj == nil ifFalse:[lastObj nextObj: nil].
