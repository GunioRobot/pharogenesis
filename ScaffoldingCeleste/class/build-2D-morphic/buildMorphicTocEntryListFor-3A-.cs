buildMorphicTocEntryListFor: model 
	^(super buildMorphicTocEntryListFor: model)
		enableDragNDrop:  true;
		yourself