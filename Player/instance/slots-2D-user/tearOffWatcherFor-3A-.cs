tearOffWatcherFor: aSlotName
	| aWatcher precision getSel |
	aWatcher _ UpdatingStringMorph new.
	getSel _ ScriptingSystem getterSelectorFor: aSlotName.
	((self typeForSlot: aSlotName) = #number)
		ifFalse:
			[aWatcher useStringFormat]
		ifTrue:
			[precision _ self defaultFloatPrecisionFor: getSel.
			precision ~= 1 ifTrue: [aWatcher floatPrecision: precision]].

	aWatcher growable: true;
		getSelector: getSel;
		putSelector: (ScriptingSystem setterSelectorFor: aSlotName);
		setNameTo: aSlotName.
 	aWatcher target: self.
	aWatcher step.
	aWatcher fitContents.
	self currentHand attachMorph: aWatcher