isEmpty
	"Answer whether the receiver contains any elements."

	^(methodChanges isEmpty and: [classChanges isEmpty]) and: [classRemoves isEmpty]