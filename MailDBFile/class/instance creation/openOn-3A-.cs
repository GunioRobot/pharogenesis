openOn: fileName
	"Answer a new instance of me, backed by the file with the given name, and open it"

	^(self on: fileName) open; yourself