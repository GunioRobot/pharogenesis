editFile
	"Open a simple Edit window"
	listIndex = 0 ifTrue: [^ self].
	(directory oldFileNamed: fileName) edit