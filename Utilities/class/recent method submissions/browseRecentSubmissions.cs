browseRecentSubmissions
	"Open up a browser on the most recent methods submitted in the image.  5/96 sw."

	"Utilities browseRecentSubmissions"

	| recentMessages |

	self recentMethodSubmissions size == 0 ifTrue:
		[^ self inform: 'There are no recent submissions'].
	
	recentMessages _ RecentSubmissions copy reversed.
	RecentMessageSet 
		openMessageList: recentMessages 
		name: 'Recent submissions -- youngest first ' 
		autoSelect: nil