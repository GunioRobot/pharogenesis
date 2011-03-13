fileOutChangeSetsNamed: nameList
	"File out the list of change sets whose names are provided"
     "ChangeSorter fileOutChangeSetsNamed: #('New Changes' 'miscTidies-sw')"

	| notFound aChangeSet infoString empty |
	notFound _ OrderedCollection new.
	empty _ OrderedCollection new.
	nameList do:
		[:aName | (aChangeSet _ self named: aName)
			ifNotNil:
				[aChangeSet isEmpty
					ifTrue:
						[empty add: aName]
					ifFalse:
						[aChangeSet fileOut]]
			ifNil:
				[notFound add: aName]].

	infoString _ (nameList size - notFound size) printString, ' change set(s) filed out'.
	notFound size > 0 ifTrue:
		[infoString _ infoString, '

', notFound size printString, ' change set(s) not found:'.
		notFound do:
			[:aName | infoString _ infoString, '
', aName]].
	empty size > 0 ifTrue:
		[infoString _ infoString, '
', empty size printString, ' change set(s) were empty:'.
		empty do:
			[:aName | infoString _ infoString, '
', aName]].

	self inform: infoString