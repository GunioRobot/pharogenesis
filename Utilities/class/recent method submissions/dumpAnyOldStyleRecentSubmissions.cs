dumpAnyOldStyleRecentSubmissions

	"simplify conversion by purging those recent submissions which are still Strings"

	RecentSubmissions := self recentMethodSubmissions reject: [ :each |
		each isString
	].