shortControlSpecs
	^ #(
		spacer
		variableSpacer
		( '<'	previousPage		'Previous page')
		spacer
		('¥'		invokeBookMenu 'Click here to get a menu of options for this book.')
		spacer
		('>'	nextPage			'Next page')
		variableSpacer
		('×'	showMoreControls	'More controls'))