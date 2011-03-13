accept 
	view hasUnacceptedEdits ifFalse: [^ view flash].
	(view setText: paragraph text from: self) ifTrue:
		[initialText _ paragraph text copy.
		view ifNotNil: [view hasUnacceptedEdits: false]].
