testNonExistentDirectory

	| directory parentDirectory |
	directory _FileDirectory default
				directoryNamed: 'nonExistentFolder'.
	self shouldnt: [directory exists] 
		description: 'A FileDirectory instance should know if it points to a non-existent directory.'.

	parentDirectory _FileDirectory default.
	self shouldnt: [parentDirectory directoryExists: 'nonExistentFolder'] 
		description: 'A FileDirectory instance should know when a directory of the given name doesn''t exist'.
