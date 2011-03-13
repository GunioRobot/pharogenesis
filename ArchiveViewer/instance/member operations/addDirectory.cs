addDirectory
	| directory |
	self canAddMember ifFalse: [ ^self ].
	directory := FileList2 modalFolderSelector.
	directory
		ifNil: [^ self].
	archive addTree: directory removingFirstCharacters: directory pathName size + 1.
	self memberIndex: 0.
	self changed: #memberList.