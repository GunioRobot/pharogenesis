serviceBroadcastUpdate
	"Answer a service for broadcasting a file as an update"

	^ SimpleServiceEntry
		provider: self 
		label: 'broadcast as update'
		selector: #putUpdate:
		description: 'broadcast file as update'
		buttonLabel: 'broadcast'