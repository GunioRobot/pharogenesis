initialize
	"Initialize the receiver"
	Preferences
		addPreference: #showWorldMainDockingBar
		categories: #(#'docking bars' )
		default: true
		balloonHelp: 'Whether world''s main docking bar should be shown or not.'
		projectLocal: true
		changeInformee: TheWorldMainDockingBar
		changeSelector: #showWorldMainDockingBarPreferenceChanged.
	""
	SystemChangeNotifier uniqueInstance noMoreNotificationsFor: self.
	SystemChangeNotifier uniqueInstance
		notify: self
		ofSystemChangesOfItem: #method
		using: #updateInstances:.
	""
	Locale addLocalChangedListener: self.
	self setTimeStamp