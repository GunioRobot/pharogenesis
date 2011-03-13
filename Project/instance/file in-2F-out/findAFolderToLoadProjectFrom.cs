findAFolderToLoadProjectFrom

	self couldOpenInMorphic ifTrue: [
		^FileList2 modalFolderSelectorForProjectLoad
	] ifFalse: [
		^PluggableFileList getFolderDialog openLabel: 'Select a folder on a server:'
	]