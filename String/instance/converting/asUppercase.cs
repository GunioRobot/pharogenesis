asUppercase
	"Answer a String made up from the receiver whose characters are all 
	uppercase."

	^ self collect: [:each | each asUppercase]