browseClassVariables
	"Browse the class variables of the selected class. 2/5/96 sw"
	| cls |
	cls _ self selectedClass.
	cls
		ifNotNil: [self systemNavigation  browseClassVariables: cls]
