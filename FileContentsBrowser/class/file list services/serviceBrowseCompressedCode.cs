serviceBrowseCompressedCode
	"Answer a service for opening a changelist browser on a file"

	^ (SimpleServiceEntry 
		provider: self 
		label: 'code-file browser'
		selector: #browseCompressedCodeStream:
		description: 'open a "file-contents browser" on this file, allowing you to view and selectively load its code'
		buttonLabel: 'code')
		argumentGetter: [ :fileList | fileList readOnlyStream ]