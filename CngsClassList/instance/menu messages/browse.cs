browse
	"Create and schedule a message browser on the selected class (and message)."

	| myClass |
	controller controlTerminate.
	myClass _ self selectedClassOrMetaClass.
	myClass notNil ifTrue: [
		Browser postOpenSuggestion: 
			(Array with: myClass with: parent selectedMessageName).
		Browser newOnClass: self selectedClass].
	controller controlInitialize