atPin: anInteger 
	"Answer my element at index anInteger. at: is used by a knowledgeable client to access an existing element.   Return the first or last element if index is out of bounds.  6/18/96 tk"

anInteger < 1
	ifTrue: [^ self first]
	ifFalse: [anInteger + firstIndex - 1 > lastIndex
		ifTrue: [^ self last]
		ifFalse: [^ array at: anInteger + firstIndex - 1]]