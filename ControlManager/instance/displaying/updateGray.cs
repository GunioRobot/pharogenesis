updateGray
	"From Georg Gollmann - 11/96.  tell the Screen Controller's model to use the currently-preferred desktop color."

	"ScheduledControllers updateGray"
	(screenController view model isMemberOf: InfiniteForm)
		ifTrue: [screenController view model: (InfiniteForm with:
Preferences desktopColor)]