fileName
	"Answer the name of my file."

	file ifNil: [^ ''].
	^ file fullName
