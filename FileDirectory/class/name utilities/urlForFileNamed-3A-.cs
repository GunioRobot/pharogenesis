urlForFileNamed: aFilename 
	"Create a URL for the given fully qualified file name"
	"FileDirectory urlForFileNamed: 
	'C:\Home\andreasr\Squeak\DSqueak3\DSqueak3_1.1\DSqueak3.1.image' "
	| path localName |
	DirectoryClass
		splitName: aFilename
		to: [:p :n | 
			path _ p.
			localName _ n].
	^ localName asUrlRelativeTo: (self on: path) url asUrl