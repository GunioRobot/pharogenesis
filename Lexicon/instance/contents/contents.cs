contents
	"We have a class, allow new messages to be defined"

	editSelection == #newMessage ifTrue: [^ targetClass sourceCodeTemplate].
	^ super contents