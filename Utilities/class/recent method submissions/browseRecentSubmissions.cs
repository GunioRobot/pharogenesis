browseRecentSubmissions
	"Open up a browser on the most recent methods submitted in the image.  5/96 sw.
	5/29/96 sw: fixed so the browser doesn't go all wonkie after you submit more code"

	"Utilities browseRecentSubmissions"
	| count |
	(count _ self recentMethodSubmissions size) == 0 ifTrue:
		[^ self notify: 'There are no recent submissions'].
	
	Smalltalk browseMessageList: RecentSubmissions copy name: 'Recently submitted methods -- oldest first' autoSelect: nil 