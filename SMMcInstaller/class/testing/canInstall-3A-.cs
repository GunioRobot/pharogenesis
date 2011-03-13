canInstall: aPackage
	"Is this a Monticello package and do I have MCInstaller
	or Monticello available?"

	| fileName |
	((Smalltalk includesKey: #MCMczReader) or: [
		 Smalltalk includesKey: #MczInstaller])
			ifTrue: [
				fileName := aPackage downloadFileName.
				fileName ifNil: [^false].
				^ 'mcz' = (FileDirectory extensionFor: fileName) asLowercase].
	^false