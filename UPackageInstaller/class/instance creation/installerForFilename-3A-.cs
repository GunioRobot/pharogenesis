installerForFilename: filename
	^self registeredInstallers detect: [ :i | i handlesFilename: filename ] ifNone: [ self error: 'no installer handles file ', filename ].