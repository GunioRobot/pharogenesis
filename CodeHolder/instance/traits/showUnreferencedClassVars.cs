showUnreferencedClassVars
	"Search for all class variables known to the selected class, and put up a 
	list of those that have no references anywhere in the system. The 
	search includes superclasses, so that you don't need to navigate your 
	way to the class that defines each class variable in order to determine 
	whether it is unreferenced"
	| cls aList aReport |
	((cls _ self selectedClass) isNil or: [cls isTrait]) ifTrue: [^ self].
	aList _ self systemNavigation allUnreferencedClassVariablesOf: cls.
	aList size == 0
		ifTrue: [^ self inform: 'There are no unreferenced
class variables in
' , cls name].
	aReport _ String
				streamContents: [:aStream | 
					aStream nextPutAll: 'Unreferenced class variable(s) in ' , cls name;
						 cr.
					aList
						do: [:el | aStream tab; nextPutAll: el; cr]].
	Transcript cr; show: aReport.
	(SelectionMenu labels: aList selections: aList)
		startUpWithCaption: 'Unreferenced
class variables in 
' , cls name