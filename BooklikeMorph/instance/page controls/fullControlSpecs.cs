fullControlSpecs

	^ #(
		spacer
		variableSpacer
		('-'			deletePage		'Delete this page')
		spacer
		( 'Ç'		firstPage		'First page')
		spacer
		( '<' 		previousPage	'Previous page')
		spacer
		('¥'		invokeBookMenu 'Click here to get a menu of options for this book.')
		spacer
		('>'			nextPage		'Next page')
		spacer
		( 'È'		lastPage			'Final page')
		spacer
		('+'			insertPage		'Add a new page after this one')
		variableSpacer
		('×'			fewerPageControls	'Fewer controls')
)