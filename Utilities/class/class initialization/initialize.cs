initialize
	"Initialize the class variables.  5/16/96 sw"
	self initializeCommonRequestStrings.
	RecentSubmissions _ OrderedCollection new.

	self registerInFlapsRegistry.	