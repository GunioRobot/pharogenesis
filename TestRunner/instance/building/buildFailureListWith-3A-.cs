buildFailureListWith: aBuilder
	^ aBuilder pluggableListSpec new
		model: self;
		name: 'Failure List';
		list: #failedList; 
		getIndex: #failedSelected; 
		setIndex: #failedSelected:;
		yourself.