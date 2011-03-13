accept 
	"Overridden to allow accept of clean text"
	(view setText: paragraph text from: self) ifTrue:
		[initialText _ paragraph text copy.
		view ifNotNil: [view hasUnacceptedEdits: false]].
