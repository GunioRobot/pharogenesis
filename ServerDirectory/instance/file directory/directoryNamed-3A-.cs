directoryNamed: localFileName
	"Return a copy of me pointing at this directory below me"

	| new |
	new _ self copy.
	new directory: directory, self pathNameDelimiter asString, localFileName.
	^ new