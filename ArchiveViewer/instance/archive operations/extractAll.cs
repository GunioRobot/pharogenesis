extractAll
	| directory |

	self canExtractAll ifFalse: [^ self].
	directory _ FileList2 modalFolderSelector ifNil: [^ self].
	archive extractAllTo: directory.