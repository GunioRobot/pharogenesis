recentSubmissionsWindow
	"Answer a SystemWindow holding recent submissions"

	| recentMessages messageSet |
	recentMessages _ RecentSubmissions copy reversed.
	messageSet _ RecentMessageSet messageList: recentMessages.
	messageSet autoSelectString: nil.
	^ (messageSet inMorphicWindowLabeled: 'Recent submissions -- youngest first') applyModelExtent

	"Utilities recentSubmissionsWindow openInHand"

