pointersToItem: index of: anArray
	"Find all occurrences in the system of pointers to the given element of the given array. This is useful for tracing up a pointer chain from an inspector on the results of a previous call of pointersTo:. To find out who points to the second element of the results, one would evaluate:

	Smalltalk pointersToItem: 2 of: self

in the inspector."
	self deprecated: 'Use PointerFinder pointersToItem: index of: anArray'.
	^ self pointersTo: (anArray at: index) except: (Array with: anArray)