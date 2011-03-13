authorControlSpecs
	^ #(	
			( '<--'		firstPage		'Go to first page')
			( '<-' 		previousPage	'Go to previous page')
			('-'			deletePage		'Delete current page')
			('<<>>'		invokeBookMenu 'Get a menu')
			('+'			insertPage		'Insert new page after this one')
			('->'			nextPage		'Go to next page')
			( '-->'		lastPage			'Go to final page'))