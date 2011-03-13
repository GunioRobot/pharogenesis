recentMethodSubmissions
	"Answer the list of recent method submissions, in order.  5/16/96 sw"

	RecentSubmissions == nil ifTrue: [RecentSubmissions _ OrderedCollection new].
	^ RecentSubmissions