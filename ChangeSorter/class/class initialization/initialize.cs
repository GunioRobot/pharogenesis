initialize
	"Initialize the class variables"

	AllChangeSets == nil ifTrue:
		[AllChangeSets _ OrderedCollection new].
	self gatherChangeSets.
	ChangeSetCategories ifNil:
		[self initializeChangeSetCategories].
	RecentUpdateMarker _ 0.

	"ChangeSorter initialize"

	FileList registerFileReader: self.

	self registerInFlapsRegistry.
