addTilesForPlayerParts
	(scriptedPlayer slotNamesAndTypesForViewerBank: partsBank) do:
		[:quint | self addMorphBack:  (self 
			aRowForPart: 	quint first 
			type:			quint second
			readOnly:		(quint third == #readOnly)
			getSelector:		quint fourth
			putSelector:		quint fifth)]