serviceAddToNewZip
	"Answer a service for adding the file to a new zip"

	^ FileModifyingSimpleServiceEntry 
		provider: self
		label: 'add file to new zip'
		selector: #addFileToNewZip:
		description: 'add file to new zip'
		buttonLabel: 'to new zip'