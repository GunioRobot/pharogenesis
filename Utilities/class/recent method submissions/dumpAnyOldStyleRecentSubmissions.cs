dumpAnyOldStyleRecentSubmissions

	"simplify conversion by purging those recent submissions which are still Strings"

	RecentSubmissions _ self recentMethodSubmissions reject: [ :each |
		each isString
	].