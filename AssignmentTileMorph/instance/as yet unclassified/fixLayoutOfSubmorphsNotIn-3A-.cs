fixLayoutOfSubmorphsNotIn: aCollection 
	super fixLayoutOfSubmorphsNotIn: aCollection.
	self updateLiteralLabel; updateWordingToMatchVocabulary; layoutChanged; fullBounds