on: pathName
	"Return a new instance for the directory the given path. (The instance is of the appropriate subclass for the current OS platform)."

	^ self activeDirectoryClass new setPathName: pathName
