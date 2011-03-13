initialize
	"Initialize the class variables"
	ChangeSetCategories ifNil:
		[self initializeChangeSetCategories].
	RecentUpdateMarker := 0.

	"ChangeSorter initialize"

	FileList registerFileReader: self.

	self registerInFlapsRegistry.
