findAFolderToStoreProjectIn

	"Alan wants something prettier with a default"

	self couldOpenInMorphic ifTrue: [
		^FileList2 modalFolderSelectorForProject: self
	] ifFalse: [
		^PluggableFileList getFolderDialog openLabel: 'Select a folder on a server:'
	]