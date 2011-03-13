fileOutMessage
	"Put a description of the selected message on a file"

	self selectedMessageName ifNotNil: [
		self selectedClassOrMetaClass fileOutMethod: self selectedMessageName]