handlesFilename: filename
	^self handlesFileEnding: (FileDirectory extensionFor: filename)
	