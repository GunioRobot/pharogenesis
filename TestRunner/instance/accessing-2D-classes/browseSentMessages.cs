browseSentMessages
	| references |
	references := classesSelected gather: [ :class |
		class methodDict values , class class methodDict values gather: [ :method |
			(method literals copyWithoutAll: class allSelectors , class class allSelectors)
				select: [ :each | each isSymbol ] ] ].
	self systemNavigation
		browseAllImplementorsOfList: references asSet
		title: 'Sent Messages'.