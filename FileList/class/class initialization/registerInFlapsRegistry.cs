registerInFlapsRegistry
	"Register the receiver in the system's flaps registry"
	self environment
		at: #Flaps
		ifPresent: [:cl | cl registerQuad: #(FileList					prototypicalToolWindow		'File List'			'A File List is a tool for browsing folders and files on disks and on ftp types.') 
						forFlapNamed: 'Tools']