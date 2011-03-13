serviceFileIn
	"Answer a service for filing in an entire file"

	^ SimpleServiceEntry 
		provider: self 
		label: 'fileIn entire file'
		selector: #fileIn:
		description: 'file in the entire decompressed contents of the file, which is expected to contain Smalltalk code in fileout ("chunk") format'
		buttonLabel: 'filein'

