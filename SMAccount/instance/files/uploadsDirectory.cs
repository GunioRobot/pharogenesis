uploadsDirectory
	"Get the directory for uploaded files, create it if missing."

	^(self directory directoryNamed: 'uploads') assureExistence; yourself
