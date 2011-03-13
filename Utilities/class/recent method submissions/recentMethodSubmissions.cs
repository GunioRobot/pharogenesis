recentMethodSubmissions
	"Answer the list of recent method submissions, in order.  5/16/96 sw"

	RecentSubmissions ifNil: [RecentSubmissions := OrderedCollection new].
	^ RecentSubmissions