readoutFor: partName type: partType readOnly: readOnly getSelector: getSelector putSelector: putSelector
	| readout |
 	(partType == #player) ifTrue:
		[readout _ PlayerReferenceReadout new objectToView: scriptedPlayer viewSelector: getSelector putSelector: putSelector].

	(partType == #color) ifTrue:
		[readout _ UpdatingRectangleMorph new
		getSelector: (ScriptingSystem getterSelectorFor: partName);
		target: scriptedPlayer costume renderedMorph;
		borderWidth: 1;
		extent:  22@22.
		putSelector == #unused ifFalse: [readout putSelector: (ScriptingSystem setterSelectorFor: partName)]].

	readout ifNil: [readout _ scriptedPlayer costume updatingTileForArgType: partType partName: partName getSelector: getSelector putSelector: putSelector].
	readout step.
	^ readout