serviceAddNewFile
	"Answer a service entry characterizing the 'add new file' command"

	^ SimpleServiceEntry provider: self label: 'add new file' selector: #addNewFile description: 'create a new,. empty file, and add it to the current directory.'