publishingServers

	| dir nameToShow dirList |

	dirList _ OrderedCollection new.
	ServerDirectory serverNames do: [ :n | 
		dir _ ServerDirectory serverNamed: n.
		(dir isProjectSwiki and: [dir acceptsUploads])
			 ifTrue: [
				nameToShow _ n.
				dirList add: ((dir directoryWrapperClass with: dir name: nameToShow model: self)
					balloonText: dir realUrl)]].
	^dirList