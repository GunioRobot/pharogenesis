asciiDirectoryDelimiter
	^ self cCode: 'dir_Delimitor()' inSmalltalk: [FileDirectory pathNameDelimiter asciiValue]