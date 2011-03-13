tearOffFancyWatcherFor: aSlotName
	| aWatcher aTile getSel aLine aColor aTower precision |
	aColor _ Color r: 0.387 g: 0.581 b: 1.0.
	aLine _ AlignmentMorph newRow vResizing: #shrinkWrap; color: aColor.
	aLine layoutInset: -1.
	aLine borderWidth: 1; borderColor: aColor darker.
	aLine addMorphBack: (self tileReferringToSelf borderWidth: 0; typeColor: aColor; color: aColor; bePossessive).
	aLine addTransparentSpacerOfSize: (4@0).
	aTower _ AlignmentMorph newColumn color: aColor.
	aTower addTransparentSpacerOfSize: (0 @ 1).
	aTower addMorphBack: (StringMorph contents: aSlotName, ' = ' font: ScriptingSystem fontForTiles).
	aLine addMorphBack: aTower.
	aTile _ NumericReadoutTile new typeColor: aColor.
	aWatcher _ UpdatingStringMorph new.
	(precision _ self defaultFloatPrecisionFor: (getSel _ ScriptingSystem getterSelectorFor: aSlotName)) ~= 1 ifTrue:
		[aWatcher floatPrecision: precision].
	aWatcher growable: true;
		getSelector: getSel;
		putSelector: (ScriptingSystem setterSelectorFor: aSlotName).
	aWatcher target: self.
	aTile addMorphBack: aWatcher.
	aTile addArrows.
	aTile setLiteralTo: (self perform: getSel) width: 30.
	aLine addMorphBack: aTile.
	aWatcher step; fitContents.
	self currentHand attachMorph: aLine