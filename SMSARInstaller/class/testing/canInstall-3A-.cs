canInstall: aPackage
	"Answer if this class can install the package.
	We handle it if the filename has the extension
	.sar (upper and lowercase) and SARInstaller is
	present in the image to handle the install."

	| fileName |
	fileName := aPackage downloadFileName.
	fileName ifNil: [^false].
	Smalltalk at: #SARInstaller ifPresentAndInMemory: [ :installer |
			^'sar' = (FileDirectory extensionFor: fileName) asLowercase].
	^false