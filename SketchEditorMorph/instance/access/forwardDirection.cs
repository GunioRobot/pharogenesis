forwardDirection
	"The direction object will go when issued a sent forward:.  Up is
zero.  Clockwise like a compass.  From the arrow control."

	| bb result |
	bb _ (self valueOfProperty: #fwdButton).
	result _ (self center - bb vertices first) degrees - 90.0.
	result abs < 1.0e-10 ifTrue: [result _ 0].  
	"Workaround because the above can yield spurious miscroscopic but nonzero values"
	^ result