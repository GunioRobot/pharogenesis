createControlPanel
	|  aPanel aSize |
	(aPanel _ associatedMorph world allMorphs detect:
		[:aMorph | ((aMorph isKindOf: PasteUpMorph) and: [aMorph hasProperty: #controlPanel])]
				ifNone: [nil]) notNil
			ifTrue:
				[^ associatedMorph primaryHand attachMorph: aPanel].
	aSize _ 186 @ 50.

	aPanel _ PasteUpMorph new extent: aSize.
	aPanel color: Color white; padding: 9; borderWidth: 1; borderColor: Color blue.
	aPanel addAllMorphs: self toggleButtons. 
	aPanel laySubpartsOutInOneRow.
	aPanel setProperty: #controlPanel toValue: true; setNameTo: 'Control Panel'.
	associatedMorph primaryHand attachMorph: aPanel 
