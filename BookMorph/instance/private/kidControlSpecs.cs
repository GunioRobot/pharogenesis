kidControlSpecs
	true ifTrue: [^ self minimalKidsControlSpecs].

	^ #(	
			( '<--'		firstPage		'Go to first page')
			( '<-' 		previousPage	'Go to previous page')
			('->'			nextPage		'Go to next page')
			( '-->'		lastPage			'Go to final page'))