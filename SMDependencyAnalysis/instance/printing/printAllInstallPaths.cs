printAllInstallPaths
	"Follow all install paths in the tree."

	^String streamContents: [:s |
		self allInstallPaths do: [:path |
			path do: [:rel |
				s nextPutAll: rel packageNameWithVersion, ', '].
			s cr]] 