browseClassVariables
	"Browse the class varialbes of the selected class.  2/5/96 sw"

	| cls |
	(cls _ self selectedClass) ifNotNil: [cls browseClassVariables]