on: fullName
	"Answer another ServerDirectory on the partial path name.  fullName is directory path, and does include the name of the server."

	| new |
	new _ self copy.
	new fullPath: fullName.		"sets server, directory(path)"
	^ new