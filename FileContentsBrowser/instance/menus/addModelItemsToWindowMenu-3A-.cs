addModelItemsToWindowMenu: aMenu
	aMenu addLine.
	aMenu add: 
		(self showDiffs ifTrue: ['stop showing diffs'] ifFalse: ['start showing diffs'])
			  target: self action: #toggleDiffing 