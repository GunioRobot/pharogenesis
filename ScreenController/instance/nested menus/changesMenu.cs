changesMenu
	"Answer a menu for changes-related items"
	^ SelectionMenu labelList:
		#(	'keep this menu up'

			'simple change sorter'
			'dual change sorter'

			'file out current change set'
			'create new change set...'
			'browse changed methods'
			'check change set for slips'

			'isolate methods of this project'
			'propagate changes above'

			'browse recent submissions'
			'recently logged changes...'
			'recent log file...'
			)
		lines: #(1 3 7 9)
		selections: #(durableChangesMenu
openSimpleChangeSorter openChangeManager
fileOutChanges newChangeSet browseChangedMessages lookForSlips
beIsolated propagateChanges
browseRecentSubmissions browseRecentLog fileForRecentLog)
"
ScreenController new changesMenu startUp
"