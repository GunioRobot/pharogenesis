fancyWatcherFor: aGetter
	"Anser a labeled readout for viewing a value textuallyi"

	| aWatcher aColor aLine itsName aSelector aLabel |
	aWatcher _ self unlabeledWatcherFor: aGetter.
	aColor _ Color r: 0.387 g: 0.581 b: 1.0.
	aLine _ WatcherWrapper newRow.
	aLine player: self variableName: (aSelector _ Utilities inherentSelectorForGetter: aGetter).
	itsName _ aWatcher externalName.
	aWatcher setNameTo: 'readout'.
	aLine addMorphFront: (self tileReferringToSelf
				borderWidth: 0; layoutInset: 4@0;
				typeColor: aColor; 
				color: aColor; bePossessive).
	aLabel _ StringMorph contents: aSelector translated, ' = ' font: ScriptingSystem fontForTiles.
	aLabel setProperty: #watcherLabel toValue: true.
	aLine addMorphBack: aLabel.
	aLine addMorphBack: aWatcher.
	aLine setNameTo: itsName.

	^ aLine