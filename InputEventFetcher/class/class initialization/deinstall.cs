deinstall
	"InputEventFetcher deinstall"

	Default
		ifNotNil: [
			Default shutDown.
			Smalltalk removeFromStartUpList: Default class.
			Smalltalk removeFromShutDownList: Default class.
			Default := nil].
	Smalltalk removeFromStartUpList: self.
	Smalltalk removeFromShutDownList: self