browseClassVariables
	"Browse the class varialbes of the selected class.  2/5/96 sw"

	classListIndex = 0 ifTrue: [^ self].
	self selectedClass browseClassVariables