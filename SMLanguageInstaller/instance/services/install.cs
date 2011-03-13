install
	"This service should bring the package to the client, 
	unpack it if necessary and install it into the image. 
	The package is notified of the installation."

	| translator |
	self cache; unpack.
	translator := Smalltalk at: #Language ifAbsent: [Smalltalk at: #NaturalLanguageTranslator].
	[translator mergeTranslationFileNamed: unpackedFileName]
			ensure: [packageRelease noteInstalled]