limitedSuperSwikiDirectoryList

	| dir nameToShow dirList localDirName localDir |

	dirList _ OrderedCollection new.
	ServerDirectory serverNames do: [ :n | 
		dir _ ServerDirectory serverNamed: n.
		dir isProjectSwiki ifTrue: [
			nameToShow _ n.
			dirList add: ((dir directoryWrapperClass with: dir name: nameToShow model: self)
				balloonText: dir realUrl)
		].
	].
	ServerDirectory localProjectDirectories do: [ :each |
		dirList add: (FileDirectoryWrapper with: each name: each localName model: self)
	].
	"Make sure the following are always shown, but not twice"
	localDirName := SecurityManager default untrustedUserDirectory.
	localDir := FileDirectory on: localDirName.
	((ServerDirectory localProjectDirectories collect: [:each | each pathName]) includes: localDirName)
			ifFalse: [dirList add: (FileDirectoryWrapper with: localDir name: localDir localName model: self)].
	FileDirectory default pathName = localDirName
			ifFalse: [dirList add: (FileDirectoryWrapper with: FileDirectory default name: FileDirectory default localName model: self)].
	(dirList anySatisfy: [:each | each withoutListWrapper acceptsUploads])
		ifFalse: [dirList add: (FileDirectoryWrapper with: FileDirectory default name: FileDirectory default localName model: self)].
	^dirList