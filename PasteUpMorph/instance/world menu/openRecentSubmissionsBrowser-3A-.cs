openRecentSubmissionsBrowser: evt
	"Locate a recent-submissions browser, open it, and bring it to the front.  Create one if necessary.  Only works in morphic"

	self findAWindowSatisfying:
		[:aWindow | aWindow model isKindOf: RecentMessageSet] orMakeOneUsing: [Utilities recentSubmissionsWindow]
