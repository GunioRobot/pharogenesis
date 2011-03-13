noteInstalledPackageNamed: aString autoVersion: aVersion
	"Mark that the package release was just successfully installed.
	<aVersion> is the automatic version as a String.
	Can be used to inform SM of an installation not been done using SM."

	| p |
	p := self packageWithNameBeginning: aString.
	p ifNil: [self error: 'No package found with name beginning with ', aString].
	
^self noteInstalledPackage: p autoVersion: aVersion asVersion