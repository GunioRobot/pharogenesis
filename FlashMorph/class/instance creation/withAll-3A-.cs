withAll: aCollection
	^(self new) 
		addAllMorphs: aCollection;
		computeBounds;
		yourself