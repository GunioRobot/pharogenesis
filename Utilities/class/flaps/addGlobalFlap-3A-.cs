addGlobalFlap: aFlapTab
	FlapTabs ifNil: [FlapTabs _ OrderedCollection new].
	FlapTabs add: aFlapTab