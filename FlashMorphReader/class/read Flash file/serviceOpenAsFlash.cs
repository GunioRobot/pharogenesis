serviceOpenAsFlash
	"Answer a service for opening a flash file"

	^ SimpleServiceEntry 
				provider: self 
				label: 'open as Flash'
				selector: #openAsFlash:
				description: 'open file as flash'
				buttonLabel: 'open'