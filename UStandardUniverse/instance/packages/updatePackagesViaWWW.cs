updatePackagesViaWWW
	| rawPackageList newPackages |
	packagesURL ifNil: [ ^self ].
	rawPackageList _ packagesURL retrieveContents content.
	(rawPackageList withBlanksTrimmed beginsWith: '<') ifFalse: [
		"it is possible that the universe is completely empty, but more likely there was an error retrieving the document"
		^self ].

	newPackages _ UPackage decodePackagesFromXMLStream: (ReadStream on: rawPackageList).
	self packages: newPackages