initForClassesNamed: nameList title: aTitle
	"Initialize the receiver for the class-name-list and title provided"

	self systemOrganizer: SystemOrganization.
	metaClassIndicated _ false.
	defaultTitle _ aTitle.
	classList _ nameList copy.
	self class openBrowserView:  (self openSystemCatEditString: nil)
		label: aTitle

	"ClassListBrowser new initForClassesNamed: #(Browser CategoryViewer) title: 'Frogs'"