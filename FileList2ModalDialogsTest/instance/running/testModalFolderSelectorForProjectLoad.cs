testModalFolderSelectorForProjectLoad
	| window fileList2 w |
	window _ FileList2
		morphicViewProjectLoader2InWorld: self currentWorld
		reallyLoad: false.
	fileList2 _ window valueOfProperty: #FileList.
	w _ self currentWorld.
	window position: w topLeft + (w extent - window extent // 2).
	window openInWorld: w.
	window delete.
	self assert: fileList2 getSelectedDirectory withoutListWrapper isNil.
	fileList2 okHit.
	self deny: fileList2 getSelectedDirectory withoutListWrapper isNil
