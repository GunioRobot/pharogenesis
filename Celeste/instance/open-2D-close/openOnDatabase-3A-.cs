openOnDatabase: aMailDB
	"Initialize myself for the mail database with the given root filename."

	mailDB _ aMailDB.
	lastCategory _ ''.
	self filtersChanged