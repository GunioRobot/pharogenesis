eventHandler: anEventHandler
	"Note that morphs can share eventHandlers and all is OK.  "
	extension == nil ifTrue: [self assureExtension].
	extension eventHandler: anEventHandler