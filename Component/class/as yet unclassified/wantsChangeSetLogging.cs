wantsChangeSetLogging
	"Log changes for Component itself, but not for automatically-created subclasses like Component1, Component2"

	"^ self == Component or:
		[(self class name beginsWith: 'Component') not]"

	"Log everything for now"
	false ifTrue: [self halt  "DONT FORGET TO REORDER FILEOUT"].
	^ true