serviceBrowseCode
	"Answer the service of opening a file-contents browser"

	^ (SimpleServiceEntry
		provider: self 
		label: 'code-file browser'
		selector: #browseStream:
		description: 'open a "file-contents browser" on this file, allowing you to view and selectively load its code'
		buttonLabel: 'code')
		argumentGetter: [ :fileList | fileList readOnlyStream ]