methodHierarchy 
	"Create and schedule a message set browser on all implementors of the 
	currently selected message selector. Do nothing if no message is selected."
	| sel list tab stab |
	messageListIndex = 0 ifTrue: [^ self].
	sel _ self selectedMessageName.
	list _ OrderedCollection new.
	tab _ ''.
	self selectedClassOrMetaClass allSuperclasses reverseDo:
		[:cl |
		(cl includesSelector: sel) ifTrue:
			[list addLast: tab , cl name, ' ', sel].
		tab _ tab , '  '].
	self selectedClassOrMetaClass allSubclassesWithLevelDo:
		[:cl :level |
		(cl includesSelector: sel) ifTrue:
			[stab _ ''.  1 to: level do: [:i | stab _ stab , '  '].
			list addLast: tab , stab , cl name, ' ', sel]]
	 	startingLevel: 0.
	Smalltalk browseMessageList: list
		name: 'Inheritance of ' , self selectedMessageName