addGlobalFlap: aFlapTab
	"Add the given flap tab to the list of shared flaps"

	SharedFlapTabs ifNil: [SharedFlapTabs _ OrderedCollection new].
	SharedFlapTabs add: aFlapTab