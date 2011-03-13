open
	"Open a view on this world.  Seemingly never called currently"
	| label |
	(label _ self externalName) ifNil:
		[label _ 'Untiled E-Toy'].
	EToyWorldView openOn: self label: label