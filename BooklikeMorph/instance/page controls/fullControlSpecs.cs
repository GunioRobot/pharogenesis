fullControlSpecs

	^ #(
		spacer
		variableSpacer
		('-'			deletePage		'Delete this page')
		spacer
		( '�'		firstPage		'First page')
		spacer
		( '<' 		previousPage	'Previous page')
		spacer
		('�'		invokeBookMenu 'Click here to get a menu of options for this book.')
		spacer
		('>'			nextPage		'Next page')
		spacer
		( '�'		lastPage			'Final page')
		spacer
		('+'			insertPage		'Add a new page after this one')
		variableSpacer
		('�'			fewerPageControls	'Fewer controls')
)