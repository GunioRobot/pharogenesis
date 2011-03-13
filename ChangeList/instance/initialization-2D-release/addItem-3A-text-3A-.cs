addItem: item text: text
	| cr |
	cr _ Character cr.
	changeList addLast: item.
	list addLast: (text collect: [:x | x = cr ifTrue: [$/] ifFalse: [x]])