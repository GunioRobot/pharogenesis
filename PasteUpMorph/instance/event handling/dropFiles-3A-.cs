dropFiles: anEvent
	"Handle a number of dropped files from the OS.
	TODO:
		- use a more general mechanism for figuring out what to do with the file (perhaps even offering a choice from a menu)
		- remember the resource location or (when in browser) even the actual file handle
	"
	| numFiles stream handler |
	numFiles _ anEvent contents.
	1 to: numFiles do: [:i |
		stream _ FileStream requestDropStream: i.
		handler _ ExternalDropHandler lookupExternalDropHandler: stream.
		[handler ifNotNil: [handler handle: stream in: self dropEvent: anEvent]]
			ensure: [stream close]].