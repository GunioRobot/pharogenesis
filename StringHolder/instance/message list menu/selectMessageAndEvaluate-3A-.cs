selectMessageAndEvaluate: aBlock
	"Present a menu of the currently selected message, as well as
	all messages sent by it. Evalute aBlock with the selector of the 
	message chosen. Do nothing if no message is chosen."

	| selector method messages |
	(selector _ self selectedMessageName) ifNil: [^ self].
	method _ self selectedClassOrMetaClass 
		compiledMethodAt: selector
		ifAbsent: [].
	(method isNil or: [(messages _ method messages) size == 0])
		 ifTrue: [^ aBlock value: selector].
	Smalltalk 
		showMenuOf: messages
		withFirstItem: selector
		ifChosenDo: [:sel | aBlock value: sel]