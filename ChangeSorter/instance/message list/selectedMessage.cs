selectedMessage
	"Answer a copy of the source code for the selected message selector." 

	^ contents ifNil: [''] ifNotNil: [contents copy]