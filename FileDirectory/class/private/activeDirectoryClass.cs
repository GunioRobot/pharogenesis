activeDirectoryClass
	"Return the concrete FileDirectory subclass for the platform on which we are currently running."

	| platformDelimiter |
	platformDelimiter _ self primPathNameDelimiter.
	FileDirectory allSubclasses do: [:class |
		class pathNameDelimiter = platformDelimiter ifTrue: [^ class]].

	"no responding subclass; use FileDirectory"
	^ FileDirectory
