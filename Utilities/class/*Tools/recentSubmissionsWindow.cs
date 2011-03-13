recentSubmissionsWindow
	"Answer a SystemWindow holding recent submissions"

	| recentMessages messageSet |
	recentMessages := RecentSubmissions copy reversed.
	messageSet := RecentMessageSet messageList: recentMessages.
	messageSet autoSelectString: nil.
	^ (messageSet inMorphicWindowLabeled: 'Recent submissions -- youngest first') applyModelExtent

	"Utilities recentSubmissionsWindow openInHand"

