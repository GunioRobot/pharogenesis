selectedClass
	| class |
	listIndex = 0 ifTrue: [^ nil].
	class _ self selectedClassOrMetaClass.
	^ class theNonMetaClass		"the class, or soleInstance if its a metaclass"