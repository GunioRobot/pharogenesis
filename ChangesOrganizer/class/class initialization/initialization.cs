initialization

	"Initialize the class variables"	
	ChangeSetCategories ifNil:		
		[self initializeChangeSetCategories].	
		
	RecentUpdateMarker := 0.