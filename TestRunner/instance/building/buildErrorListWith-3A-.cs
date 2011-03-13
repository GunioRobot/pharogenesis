buildErrorListWith: aBuilder
	^ aBuilder pluggableListSpec new
		model: self;
		name: 'Error List';
		list: #errorList; 
		getIndex: #errorSelected; 
		setIndex: #errorSelected:;
		yourself.