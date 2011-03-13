viewChanges: patch
	"Open a browser on the given patch."

	Preferences useNewDiffToolsForMC
		ifTrue: [((PSMCPatchMorph forPatch: patch) newWindow)
					title: 'Changes to ', workingCopy description;
					open]
		ifFalse: [(MCPatchBrowser forPatch: patch)
					label: 'Patch Browser: ', workingCopy description;
					show]