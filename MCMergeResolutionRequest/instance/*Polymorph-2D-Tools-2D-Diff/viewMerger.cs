viewMerger
	"Open a model browser to perform the merge and answer wheter merged."

	^Preferences useNewDiffToolsForMC
		ifTrue: [self viewPatchMerger]
		ifFalse: [(MCMergeBrowser new
					merger: merger;
					label: messageText) showModally]