directoryNamed: localFileName
	"Return a copy of me pointing at this directory below me"

	| new |
	new _ self copy.
	urlObject ifNotNil: [
		new urlObject path: (new urlObject path) copy.
		(new urlObject path) removeLast; addLast: localFileName; addLast: ''.
		^ new].
	new directory: directory, self pathNameDelimiter asString, localFileName.
	^ new