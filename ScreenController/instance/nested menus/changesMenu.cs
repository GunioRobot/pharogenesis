changesMenu
	"Answer a menu for changes-related items"


	ChangesMenu == nil ifTrue: 
		[ChangesMenu _ SelectionMenu labelList:
		#(	'file out changes'
			'open changes sorter'
			'browse changed methods'
			'browse recent submissions'
			'recent change log')
		lines: #(1 4)
		selections: #(fileOutChanges openChangeManager browseChangedMessages browseRecentSubmissions browseRecentLog)].

	^ ChangesMenu

"
ScreenController new changesMenu startUp
"