actOnClickFor: evt 
	| choice viewMsg |
	viewMsg _ message containsViewableImage
		ifTrue: ['view this image attachment']
		ifFalse: ['view this attachment'].
	choice _ UIManager default chooseFrom: (Array with: viewMsg 
													with: 'save this attachment' ).
	choice = 1
		ifTrue: ["open a new viewer"
			message viewBody].
	choice = 2
		ifTrue: ["save the mesasge"
			message save].
	^ true