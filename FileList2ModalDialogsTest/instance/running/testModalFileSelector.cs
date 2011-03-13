testModalFileSelector
	| window fileList2 |
	window := FileList2 morphicViewFileSelector.
	window openCenteredInWorld.
	fileList2 := window valueOfProperty: #fileListModel.
	fileList2 fileListIndex: 1.
	window delete.
	self assert: fileList2 getSelectedFile isNil.
	fileList2 okHit.
	self deny: fileList2 getSelectedFile isNil


