clearExternalObjects
	"Clear the array of objects that have been registered for use in non-Smalltalk code."

	ProtectTable critical: [Smalltalk specialObjectsArray at: 39 put: Array new].
