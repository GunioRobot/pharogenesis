pathParts
	"Return the path from the root of the file system to this directory as an array of directory names.  On a remote server."

	^ (OrderedCollection with: server) addAll: 
		(directory findTokens: self pathNameDelimiter asString);
			yourself.
