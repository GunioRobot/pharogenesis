browseRecentSubmissions
	"Open up a browser on the most recent methods submitted in the image.  5/96 sw.
	5/29/96 sw: fixed so the browser doesn't go all wonkie after you submit more code
	: reverse the order, have most recent submissions at the top of the list	
	: use RecentMessageList"

	"Utilities browseRecentSubmissions"

	| recentMessages |
	self recentMethodSubmissions size == 0 ifTrue:
		[^ SelectionMenu notify: 'There are no recent submissions'].
	
	recentMessages _ RecentSubmissions copy reversed.
	RecentMessageSet openMessageList: recentMessages name: 'Recently submitted methods -- youngest first ' autoSelect: nil