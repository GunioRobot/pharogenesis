openRecentSubmissionsBrowser: evt
	"Locate a recent-submissions browser, open it, and bring it to the front.  Create one if necessary.  Only works in morphic"

	| aWindow |
	submorphs do:
		[:aMorph | (((aWindow _ aMorph renderedMorph) isKindOf: SystemWindow) and:
			[aWindow model isKindOf: RecentMessageSet])
				ifTrue:
					[aWindow isCollapsed ifTrue: [aWindow expand].
					aWindow activateAndForceLabelToShow.
					^ self]].
	"None found, so create one"
	Utilities browseRecentSubmissions