removeFromGlobalFlapTabList: aFlapTab
	"If the flap tab is in the global list, remove it"

	FlapTabs remove: aFlapTab ifAbsent: []