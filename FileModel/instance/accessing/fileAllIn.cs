fileAllIn
	"FileIn all of the contents from the external file"
	| f |
	f _ FileStream oldFileNamed: self fullName.
	(self fileNameSuffix sameAs: 'html') ifTrue: [f _ f asHtml].
	f fileIn