readoutFor: partName type: partType readOnly: readOnly getSelector: getSelector putSelector: putSelector
	| readout |

 	(partType == #player) ifTrue:
		[readout _ PlayerReferenceReadout new objectToView: scriptedPlayer viewSelector: getSelector putSelector: putSelector].

	(partType == #color) ifTrue:
		[readout _ UpdatingRectangleMorph new
		target: self morph;
		getSelector: (Utilities getterSelectorFor: partName);
		borderWidth: 1;
		extent:  30@25.
		putSelector == #unused ifFalse: [readout putSelector: (Utilities setterSelectorFor: partName)]].

	readout ifNil: [readout _ self morph updatingTileForArgType: partType partName: partName getSelector: getSelector putSelector: putSelector].
	readout step.
	^ readout