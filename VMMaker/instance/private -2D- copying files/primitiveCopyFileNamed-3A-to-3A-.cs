primitiveCopyFileNamed: srcName to: dstName 
	"This really ought to be a facility in file system. The major annoyance 
	here is that file types and permissions are not handled by current 
	Squeak code"
	| buffer src dst |
	<primitive: 'primitiveFileCopyNamedTo' module:'FileCopyPlugin'> "primitiveExternalCall" 
	"If the plugin doesn't do it, go the slow way and lose the filetype info"
	"This method may signal FileDoesNotExistException if either the source or 
	dest files cannnot be opened; possibly permissions or bad name problems"
	[[src _ FileStream readOnlyFileNamed: srcName]
		on: FileDoesNotExistException
		do: [^ self couldNotOpenFile: srcName].
	[dst _ FileStream forceNewFileNamed: dstName]
		on: FileDoesNotExistException
		do: [^ self couldNotOpenFile: dstName].
	buffer _ String new: 50000.
	[src atEnd]
		whileFalse: [dst
				nextPutAll: (src nextInto: buffer)]]
		ensure: [src
				ifNotNil: [src close].
			dst
				ifNotNil: [dst close]]