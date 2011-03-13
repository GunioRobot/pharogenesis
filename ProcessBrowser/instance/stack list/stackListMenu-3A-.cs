stackListMenu: aMenu 
	| menu |
	selectedContext
		ifNil: [^ aMenu].
	menu := aMenu
				labels: 'inspect context (c)
explore context (C)
inspect receiver (i)
explore receiver (I)
browse (b)'
				lines: #(2 4 )
				selections: #(#inspectContext #exploreContext #inspectReceiver #exploreReceiver #browseContext ).
	^ menu