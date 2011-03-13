openOnDatabase: aMailDB 
	"Open a MailReader on the given mail database."
	| model topWindow title |
	model _ self new openOnDatabase: aMailDB.
	title _ self defaultWindowTitle.
	Smalltalk isMorphic
		ifTrue: [topWindow _ self
						buildTopMorphicWindowTitled: title
						model: model.
			topWindow openInWorld]
		ifFalse: [topWindow _ self buildTopMVCWindowTitled: title model: model.
			topWindow controller open].
	"in case the sender wants to know"
	^ model