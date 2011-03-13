initialize
	owner _ nil.
	submorphs _ EmptyArray.
	borderWidth _ 1.
	borderColor _ Color r: 0.861 g: 1.0 b: 0.722.
	gradientDirection _ #vertical.
	color _ Color r: 0.8 g: 1.0 b: 0.6.
	fillColor2 _ color.
	bounds _ 0@0 corner: 50@40.
	cursor _ 1.
	padding _ 3.
	autoLineLayout _ false.
	openToDragNDrop _ true.
	lastTurtlePositions _ IdentityDictionary new.
	self isWorldMorph ifFalse: [self setProperty: #suppressPhraseExpansion toValue: true]
