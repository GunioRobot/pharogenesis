error: s
	"Print an error message and exit."

	self print: 'Error in %s\n' f: s.
	self exit: -1.