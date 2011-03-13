forget
	"Remove all mention of this class from the changeSet"
	controller controlTerminate.
	listIndex = 0 ifFalse: [
		parent changeSet removeClassChanges: self selectedClassOrMetaClass.
		parent launch].
	controller controlInitialize