recreateScripts
	"self currentWorld recreateScripts."

	Preferences enable: #universalTiles.
	Preferences enable: #capitalizedReferences.
	"Rebuild viewers"
	self flapTabs do: 
			[:ff | 
			(ff isMemberOf: ViewerFlapTab) 
				ifTrue: 
					[ff referent 
						submorphsDo: [:m | (m isStandardViewer) ifTrue: [m recreateCategories]]]].
	"Rebuild scriptors"
	((self flapTabs collect: [:t | t referent]) copyWith: self) 
		do: [:w | w allScriptEditors do: [:scrEd | scrEd unhibernate]]