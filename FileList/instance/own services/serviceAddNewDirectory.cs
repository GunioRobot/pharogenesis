serviceAddNewDirectory
	"Answer a service entry characterizing the 'add new directory' command"

	^ SimpleServiceEntry 
		provider: self 
		label: 'add new directory' 
		selector: #addNewDirectory
		description: 'adds a new, empty directory (folder)' 