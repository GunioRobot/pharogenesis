is: node theNodeFor: element 
	node ifNil: [^ false].
	node == self ifTrue: [^ false].
	^ self is: node object equalTo: element