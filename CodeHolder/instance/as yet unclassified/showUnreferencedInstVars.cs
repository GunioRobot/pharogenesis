showUnreferencedInstVars
	"Search for all instance variables known to the selected class, and put up a list of those that have no references anywhere in the system.  The search includes superclasses, so that you don't need to navigate your way to the class that defines each inst variable in order to determine whether it is unreferenced"

	| cls aList aReport |
	(cls _ self selectedClass) ifNil: [^ self].
	aList _ cls allUnreferencedInstanceVariables.
	aList size == 0 ifTrue: [^ self inform: 'There are no unreferenced
instance variables in
', cls name].
	aReport _ String streamContents:
		[:aStream |
			aStream nextPutAll: 'Unreferenced instance variable(s) in ', cls name; cr.
			aList do: [:el | aStream tab; nextPutAll: el; cr]].
	Transcript cr; show: aReport.
	(SelectionMenu labels: aList selections: aList) startUpWithCaption: 'Unreferenced
instance variables in 
', cls name