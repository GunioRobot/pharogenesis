updateListsAndCodeIn: aWindow

	| recentFromUtilities |
	"RAA 20 june 2000 - a recent change to how messages were displayed in the list caused them not to match what was stored in Utilities. This caused the recent submissions to be continuously updated. The hack below fixed that problem"

	self canDiscardEdits ifFalse: [^ self].
	recentFromUtilities _ Utilities mostRecentlySubmittedMessage asString,' '.
	(messageList first asString beginsWith: recentFromUtilities)
		ifFalse:
			[self reformulateList]
		ifTrue:
			[self updateCodePaneIfNeeded]