testModalFolderSelector
	| window fileList2 |
	window _ FileList2 morphicViewFolderSelector.
	fileList2 _ window model.
	window openInWorld: self currentWorld extent: 300@400.
	fileList2 fileListIndex: 1.
	window delete.
	self assert: fileList2 getSelectedDirectory withoutListWrapper isNil.
	fileList2 okHit.
	self deny: fileList2 getSelectedDirectory withoutListWrapper isNil

