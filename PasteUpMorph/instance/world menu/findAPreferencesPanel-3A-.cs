findAPreferencesPanel: evt
	"Locate a Preferences Panel, open it, and bring it to the front.  Create one if necessary"

	| aPanel |
	self findAWindowSatisfying:
		[:aWindow | aWindow model isKindOf: PreferencesPanel] orMakeOneUsing:
			[aPanel _ Preferences preferencesControlPanel.
			"Note -- we don't really want the openInHand -- but owing to some annoying
			difficulty, if we don't, we get the wrong width.  Somebody please clean this up"
			^ aPanel openInHand]