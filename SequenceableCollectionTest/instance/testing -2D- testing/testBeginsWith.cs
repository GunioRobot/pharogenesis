testBeginsWith
	"We can't test SequenceableCollection directly. However, we can test a sampling of its descendants."

	| la prefix oc |
	la := #(1 2 3 4 5 6).
	oc := OrderedCollection new.
	oc add: 1; add: 2; add: 3.

	self assert: (la beginsWith: #(1)).
	self assert: (la beginsWith: #(1 2)).
	self assert: (la beginsWith: #(1 2 3)).
	self assert: (la beginsWith: oc).
	self deny: (la beginsWith: #()).
	self deny: (la beginsWith: '').
	self deny: (la beginsWith: OrderedCollection new).
	
	self assert: (oc beginsWith: #(1 2)).
	
	prefix := OrderedCollection new.
	self deny: (oc beginsWith: prefix).
	prefix add: 1.
	self assert: (oc beginsWith: prefix).
	prefix add: 2.
	self assert: (oc beginsWith: prefix).
	prefix add: 3.
	self assert: (oc beginsWith: prefix).
	prefix add: 4.
	self deny: (oc beginsWith: prefix).