saveConfigurationTo: aFile
	"write info about the current configuration to a file."
	| fileStream |
	fileStream _ FileStream newFileNamed: aFile.
	fileStream fileOutClass: nil andObject: self configurationInfo