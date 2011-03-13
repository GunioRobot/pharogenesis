loopTests
	| v |
	v _ 0.
	[v < 10] whileTrue: [ self printNum: v.  v _ v + 1 ].
	self print: ''.
	[v < 1] whileFalse: [ self printNum: v.  v _ v - 1 ].
	self print: ''.
	1 to: 10 do: [ :i | self printNum: i ].
	self print: ''.
	1 to: 10 by: 2 do: [ :i | self printNum: i ].
	self print: ''.