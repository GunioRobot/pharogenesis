serviceImageImportDirectory
	"Answer a service for reading a graphic into ImageImports"

	^(SimpleServiceEntry
			provider: self 
			label: 'import all images from this directory'
			selector: #importImageDirectory:
			description: 'Load all graphics found in this directory, adding them to the ImageImports repository.'
			buttonLabel: 'import dir')
			argumentGetter: [ :fileList | fileList directory ];
			yourself
