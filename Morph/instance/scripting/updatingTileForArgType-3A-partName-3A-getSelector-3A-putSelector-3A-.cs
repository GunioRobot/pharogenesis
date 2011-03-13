updatingTileForArgType: typeSymbol partName: partName getSelector: getSelector putSelector: putSelector
	"Answer a readout tile representing the given part's value, given the putter, getter, and type information"

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
					[typeSymbol == #buttonPhase
						ifTrue:
							[SymbolListTile new choices: #(buttonDown whilePressed buttonUp) dataType:  typeSymbol]
						ifFalse:
							[StringReadoutTile new typeColor: aColor]]].

 	displayer _ UpdatingStringMorph new
		getSelector: getSelector;
		target: self player;
		growable: true;
		minimumWidth: 24;
		putSelector: ((putSelector == #unused) ifTrue: [nil] ifFalse: [putSelector]).

	(typeSymbol == #number)
		ifTrue:
			 [((#(cursor  "etc...") includes: partName) and: [self isKindOf: GraphMorph])
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
	((putSelector ~~ #unused) and: [#(number sound boolean buttonPhase) includes: typeSymbol])  ifTrue: [aTile addArrows].
	aTile setLiteralInitially: (self scriptPerformer perform: getSelector).
	^ aTile