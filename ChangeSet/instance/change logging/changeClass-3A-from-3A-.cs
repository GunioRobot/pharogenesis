changeClass: class from: oldClass
	"Remember that a class definition has been changed.  Record the original structure, so that a conversion method can be built."

	class wantsChangeSetLogging ifFalse: [^ self]. 
	isolationSet ifNotNil:
		["If there is an isolation layer above me, inform it as well."
		isolationSet changeClass: class from: oldClass].
	self atClass: class add: #change.
	self addCoherency: class name.
	(self changeRecorderFor: class) notePriorDefinition: oldClass.
	self noteClassStructure: oldClass