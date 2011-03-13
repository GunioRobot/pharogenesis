update: aSymbol
	aSymbol = #sizing ifTrue: [^ self updateSizing].
	aSymbol = #panes ifTrue: [^ self updatePanes].