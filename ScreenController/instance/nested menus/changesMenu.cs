changesMenu
	"Answer a menu for changes-related items.  2/4/96 sw
	 5/8/96 sw: divided changelist options into two
	 5/17/96 sw: added browse recent submissions"

	ChangesMenu == nil ifTrue: 
		[ChangesMenu _ SelectionMenu labelList:
		#(	'file out changes'
			'browse changed methods'
			'browse recent submissions'
			'open change sorter'
			'post-snapshot change log'
			'recent change log')
		lines: #(1 4)
		selections: #(fileOutChanges browseChangedMessages browseRecentSubmissions openChangeManager browsePostSnapshotChanges browseRecentChanges)].

	^ ChangesMenu

"
ScreenController new changesMenu startUp
"