labelString
	"The label for my entire window.  The large button that displays my name is gotten via mainButtonName"

	^ String streamContents:
		[:aStream |
			aStream nextPutAll: (ChangeSet current == myChangeSet
				ifTrue: ['Changes go to "', myChangeSet name, '"']
				ifFalse: ['ChangeSet: ', myChangeSet name]).
		(self changeSetCategory categoryName ~~ #All)
			ifTrue:
				[aStream nextPutAll:  ' - ', self parenthesizedCategoryName]]