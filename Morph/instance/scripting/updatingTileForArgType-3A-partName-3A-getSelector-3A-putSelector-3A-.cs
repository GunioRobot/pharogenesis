updatingTileForArgType: typeSymbol partName: partName getSelector: getSelector putSelector: putSelector

	| aColor aTile displayer |
	aColor _ Color lightGray lighter.
	aTile _ typeSymbol == #number
		ifTrue:
			[NumericReadoutTile new typeColor: aColor]
		ifFalse:	
			[typeSymbol == #sound
				ifTrue:
					[SoundReadoutTile new typeColor: aColor]
				ifFalse:
					[StringReadoutTile new typeColor: aColor]].

 	displayer _ UpdatingStringMorph new
		getSelector: getSelector;
		target: self player;
		growable: true;
		putSelector: ((putSelector == #unused) ifTrue: [nil] ifFalse: [putSelector]).

	(typeSymbol == #number)
		ifTrue:
			 [(#(cursorWrapped  "etc...") includes: partName)
				ifTrue:
					[displayer floatPrecision: 0.1]
				ifFalse:
					[(self player slotInfo includesKey: partName)  "i.e., a user-defined numeric slot"
						ifTrue:
							[displayer floatPrecision: (self player slotInfoAt: partName) floatPrecision]]].
	typeSymbol == #string
		ifTrue:
			[displayer useStringFormat.
			displayer growable: true]
		ifFalse:
			[(typeSymbol == #sound)
				ifTrue: 	[displayer useStringFormat]
				ifFalse:	[displayer useDefaultFormat]].
	aTile addMorphBack: displayer.
	((putSelector ~~ #unused) and: [#(number sound boolean) includes: typeSymbol])  ifTrue: [aTile addArrows].
	aTile literal: (self scriptPerformer perform: getSelector).
	^ aTile