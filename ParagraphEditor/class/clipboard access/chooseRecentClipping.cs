chooseRecentClipping  "ParagraphEditor chooseRecentClipping"
	"Choose by menu from among the recent clippings"

	RecentClippings ifNil: [^ nil].
	^ (SelectionMenu
		labelList: (RecentClippings collect: [:txt | ((txt asString contractTo: 50)
									copyReplaceAll: Character cr asString with: '\')
									copyReplaceAll: Character tab asString with: '|'])
		selections: RecentClippings) startUp.

