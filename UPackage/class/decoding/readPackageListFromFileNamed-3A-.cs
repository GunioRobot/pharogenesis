readPackageListFromFileNamed: filename
	| file packages |
	file _ FileStream readOnlyFileNamed: filename.
	packages _ self decodePackagesFromXMLStream: file.
	file close.
	^packages