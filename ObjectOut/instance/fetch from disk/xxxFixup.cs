xxxFixup
	"There is already an object in memory for my url.  All pointers to me need to be pointers to him.  Can't use become, because other pointers to him must stay valid."

	| real temp list |
	real _ page contentsMorph.
	real == self ifTrue: [page error: 'should be converted by now'].
	temp _ self.
	list _ (PointerFinder pointersTo: temp) asOrderedCollection.
	list add: thisContext.  list add: thisContext sender.
	list do: [:holder |
		1 to: holder class instSize do:
			[:i | (holder instVarAt: i) == temp ifTrue: [holder instVarAt: i put: real]].
		1 to: holder basicSize do:
			[:i | (holder basicAt: i) == temp ifTrue: [holder basicAt: i put: real]].
		].
	^ real