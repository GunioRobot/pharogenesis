recentMethodSubmissions
	"Answer the list of recent method submissions, in order.  5/16/96 sw"


	self flag: #mref.	"fix for faster references to methods"

	RecentSubmissions == nil ifTrue: [RecentSubmissions _ OrderedCollection new].
	^ RecentSubmissions