accept 
	"Overridden to allow accept of clean text"
	(view setText: paragraph text from: self) ifTrue:
		[initialText := paragraph text copy.
		view ifNotNil: [view hasUnacceptedEdits: false]].
