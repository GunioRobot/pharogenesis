updateAfterClassChange
	"It is possible that some the classes comprising the hierarchy have changed, so reinitialize the entire browser."
	centralClass ifNotNil:
		[self initHierarchyForClass: centralClass]