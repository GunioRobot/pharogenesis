initialize
	owner _ nil.
	submorphs _ EmptyArray.
	borderWidth _ 1.
	borderColor _ Color r: 0.861 g: 1.0 b: 0.722.
	color _ Color r: 0.8 g: 1.0 b: 0.6.
	bounds _ 0@0 corner: 50@40.
	cursor _ 1.
	padding _ 3.
	self enableDragNDrop.
	self isWorldMorph ifTrue: [self setProperty: #automaticPhraseExpansion toValue: true].
	self clipSubmorphs: true.