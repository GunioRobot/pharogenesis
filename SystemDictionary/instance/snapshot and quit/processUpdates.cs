processUpdates
	"Process update files from a well-known update server."

	| choice |
	(Preferences valueOfFlag: #updateFromServer) ifTrue: [
		choice _ (PopUpMenu labels: 'Yes, Update\No, Not now' withCRs)
			startUpWithCaption: 'Shall I look for new code\updates on the server?' withCRs.
		choice = 1 ifTrue: [Utilities absorbUpdatesFromServer]].
