select: aMolecule 
	selected == aMolecule
		ifFalse: ["Replace the selected for the new one" selected
				ifNotNil: [selected deactivate].
			selected _ aMolecule.
			selected
				ifNotNil: [selected activate]]