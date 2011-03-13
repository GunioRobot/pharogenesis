openOnDatabase: aMailDB
	"Initialize myself for the mail database with the given root filename."

	mailDB _ aMailDB.
	mailDB addDependent: self.
	currentCategory _ 'new'.
	lastCategory _ ''.
	subjectFilter _ ''.
	fromFilter _ ''.
	participantFilter _ ''.
	dateFilter _ nil.
	self setCategory: currentCategory.
