serviceRemoveLineFeeds
	"Answer a service for removing linefeeds from a file"

	^ FileModifyingSimpleServiceEntry
		provider: self 
		label: 'remove line feeds'
		selector: #removeLineFeeds:	
		description: 'remove line feeds in file'
		buttonLabel: 'remove lfs'