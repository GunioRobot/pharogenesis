definitionST80
	^String streamContents: [:stream |
		stream nextPutAll: self class name.
		stream nextPutAll: ' named: ';
				store: self name.
		stream cr; tab; nextPutAll: 'uses: ';
				nextPutAll: self traitCompositionString.
		stream cr; tab; nextPutAll: 'category: ';
				store: self category asString].