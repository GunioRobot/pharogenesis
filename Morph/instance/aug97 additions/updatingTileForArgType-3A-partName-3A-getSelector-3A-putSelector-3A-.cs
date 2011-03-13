updatingTileForArgType: typeSymbol partName: partName getSelector: getSelector putSelector: putSelector

	| aColor aTile viewer |
	aColor _ Color lightGray lighter.
	aTile _ typeSymbol == #number
		ifTrue:	[NumericReadoutTile new typeColor: aColor]
		ifFalse:	[StringReadoutTile new typeColor: aColor].

 	viewer _ UpdatingStringMorph new
		target: self costumee;
		getSelector: getSelector;
		growable: false;
		putSelector: ((putSelector == #unused) ifTrue: [nil] ifFalse: [putSelector]).
	typeSymbol == #string
		ifTrue:
			[viewer useStringFormat]
		ifFalse:
			[viewer useDefaultFormat].
	aTile addMorphBack: viewer.
	putSelector == #unused ifFalse: [aTile addArrows].
	aTile setLiteralTo: (self scriptPerformer perform: getSelector) width: 30.
	^ aTile