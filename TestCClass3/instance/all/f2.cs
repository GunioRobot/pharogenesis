f2

	| local i |
	local _ 2.
	i _ self functionWithLabel: -2.
	i > 0 ifTrue: [ ^ -1 ].
	self print: 'f2'.