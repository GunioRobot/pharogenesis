serviceBrowseCodeFiles

	^  (SimpleServiceEntry 
		provider: self
		label: 'browse code files' 
		selector: #selectAndBrowseFile:)
		argumentGetter: [ :fileList | fileList ];
		yourself