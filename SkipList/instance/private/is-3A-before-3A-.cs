is: node before: element 
	| object |
	node ifNil: [^ false].
	object _ node object.
	^ sortBlock
		ifNil: [object < element]
		ifNotNil: [(self is: object equalTo: element) ifTrue: [^ false].
			sortBlock value: object value: element]