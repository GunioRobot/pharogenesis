processUpdates
	"Process update files from a well-known update server.  This method is called at system startup time,   Only if the preference #updateFromServerAtStartup is true is the actual update processing undertaken automatically"

	(Preferences valueOfFlag: #updateFromServerAtStartup)
		ifTrue: [
			| choice |
			choice _ (PopUpMenu labels: 'Yes, Update\No, Not now\Don''t ask again' withCRs)
				startUpWithCaption: 'Do you want to check for updates\or maintenance fixes on the server?' withCRs.
			choice = 1 ifTrue: [Utilities updateFromServer].
			choice = 3 ifTrue: [
				Preferences setPreference: #updateFromServerAtStartup toValue: false.
				self inform: 'Remember to save you image to make this setting permant.'].
		].
	^false