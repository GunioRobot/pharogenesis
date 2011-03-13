pointersToItem: index of: anArray
	"Find all occurrences in the system of pointers to the given element of the given array. This is useful for tracing up a pointer chain from an inspector on the results of a previous call of pointersTo:. To find out who points to the second element of the results, one would evaluate:

	Utilities pointersToItem: 2 of: self

in the inspector."

	self deprecated: 'Please, use PointerFinder class>>pointersToItem:of: instead' on: '10 July 2009' in: #Pharo1.0.
	^ PointerFinder pointersTo: (anArray at: index) except: (Array with: anArray)