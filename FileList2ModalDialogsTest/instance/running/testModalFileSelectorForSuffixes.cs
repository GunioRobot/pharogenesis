testModalFileSelectorForSuffixes
	| window fileList2 |
	window _ FileList2 morphicViewFileSelectorForSuffixes: nil.
	window openCenteredInWorld.
	fileList2 _ window valueOfProperty: #fileListModel.
	fileList2 fileListIndex: 1.
	window delete.
	self assert: fileList2 getSelectedFile isNil.
	fileList2 okHit.
	self deny: fileList2 getSelectedFile isNil
