fullFileName
	"answer the receiver's fullFileName"
	^ mpegFile isNil
		ifTrue: ['']
		ifFalse: [mpegFile fileName]