labelString
	"The label for my entire window.  The large button that displays my name is gotten via mainButtonName"
	^ parent 
		ifNil: [Smalltalk changes == myChangeSet
			ifTrue: ['Changes go to "', myChangeSet name, '"']
			ifFalse: ['ChangeSet: ', myChangeSet name]]
		ifNotNil: ['Changes go to "', (Smalltalk changes name), '"']