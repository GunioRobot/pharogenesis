serviceExtractAll
	"Answer a service for opening in a zip viewer"

	^ FileModifyingSimpleServiceEntry 
		provider: self
		label: 'extract all to...'
		selector: #extractAllFrom: 
		description: 'extract all files to a user-specified directory'
		buttonLabel: 'extract all'