initialize
"initialize the state of the receiver"
	super initialize.
""
	cursor _ 1.
	padding _ 3.
	self enableDragNDrop.
	self isWorldMorph
		ifTrue: [self setProperty: #automaticPhraseExpansion toValue: true].
	self clipSubmorphs: true