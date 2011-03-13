viewChanges: patch
	"Open a patch morph for the changes."
	
	|title|
	title := 'Changes from {1}' format: {self version info name}.
	Preferences useNewDiffToolsForMC
		ifTrue: [((PSMCPatchMorph forPatch: patch) newWindow)
					title: title;
					open]
		ifFalse: [(MCPatchBrowser forPatch: self version changes)
					showLabelled: title]