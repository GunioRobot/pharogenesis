processUpdates
	"Process update files from a well-known update server.  This method is called at system startup time,   Only if the preference #updateFromServerAtStartup is true is the actual update processing undertaken automatically"

	| choice |
	(Preferences valueOfFlag: #updateFromServerAtStartup) ifTrue:
		[choice _ (PopUpMenu labels: 'Yes, Update\No, Not now' withCRs)
			startUpWithCaption: 'Shall I look for new code\updates on the server?' withCRs.
		choice = 1 ifTrue: [Utilities updateFromServer]].
