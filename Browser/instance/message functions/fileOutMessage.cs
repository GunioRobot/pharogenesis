fileOutMessage
	"Print a description of the selected message"
	messageListIndex = 0 ifTrue: [^ self].
	self selectedClassOrMetaClass fileOutMethod: self selectedMessageName