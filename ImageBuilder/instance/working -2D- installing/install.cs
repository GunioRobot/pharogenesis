install
	"First load updates to the map, then install specific 
	releases of the packages needed for Full. Each of these 
	install methods either installs (if not previously installed) 
	a specific release or upgrades an existing release to it. 
	 
	To see what these are, see ImageBuilder>>packageSpecs:"
	
	SMSqueakMap default loadUpdates.
	self packageSpecs
		do: [:arr | self install: arr first autoVersion: arr second]