labelForButton

	self tileRows do: [:r |
		r do: [:t |
			t type = #operator ifTrue: [^ t operatorOrExpression]]].
	^ 'button'
