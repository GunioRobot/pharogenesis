renameTo: newName
	| oldBase |
	newName = self name
		ifFalse: [
			oldBase _ self resourceDirectoryName.
			version _ nil.
			self resourceManager adjustToRename: self resourceDirectoryName from: oldBase.
			self changeSet name: newName.
			].