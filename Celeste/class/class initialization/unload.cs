unload
	"Unload the receiver from global registries"

	TheWorldMenu unregisterOpenCommandWithReceiver: self.
	self environment at: #Flaps ifPresent: [:cl |
	cl unregisterQuadsWithReceiver: self] 