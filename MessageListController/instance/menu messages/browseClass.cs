browseClass
	"Create and schedule a class browser on the selected class and message."

	| myClass |
	self controlTerminate.
	myClass _ model selectedClassOrMetaClass.
	myClass notNil ifTrue: [
		Browser postOpenSuggestion: 
			(Array with: myClass with: model selectedMessageName).
		Browser newOnClass: model selectedClass].
	self controlInitialize