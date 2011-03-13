viewChanges: patch
	"Opene a browser on the patch."
	
	|patchLabel|
	patchLabel := 'Changes between {1} and {2}' format: { self selectedInfo name. ancestry name }.
	Preferences useNewDiffToolsForMC
		ifTrue: [((PSMCPatchMorph forPatch: patch) newWindow)
					title: patchLabel;
					open]
		ifFalse: [(MCPatchBrowser forPatch: patch)
					label: patchLabel;
					show]