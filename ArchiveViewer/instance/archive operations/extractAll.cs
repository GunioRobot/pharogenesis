extractAll
	| directory |

	self canExtractAll ifFalse: [^ self].
	directory := FileList2 modalFolderSelector ifNil: [^ self].
	archive extractAllTo: directory.