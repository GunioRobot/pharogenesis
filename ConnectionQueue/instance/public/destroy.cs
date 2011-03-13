destroy
	"Terminate the listener process and destroy all sockets in my possesion."

	process ifNotNil: [
		process terminate.
		process _ nil].
	socket ifNotNil: [
		socket destroy.
		socket _ nil].
	connections do: [:s | s destroy].
	connections _ OrderedCollection new.
