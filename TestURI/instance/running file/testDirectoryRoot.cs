testDirectoryRoot

	| rootDir uriRoot uriDir |
	rootDir := FileDirectory root.
	uriRoot := 'file:///' asURI.
	uriDir := FileDirectory uri: uriRoot.
	self should: [rootDir fullName = uriDir fullName]