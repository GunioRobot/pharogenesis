fileAllIn
	"FileIn all of the currently selected file if any."
	listIndex = 0 ifTrue: [^ self].
	super fileAllIn