testGridToGradient
	"A trivial test for checking that you can change from a grid to a  
	gradient background. A recent [FIX] will make this pass."
	| pum |
	pum _ PasteUpMorph new.
	pum setStandardTexture.
	"The following should fail without the fix"
	self
		shouldnt: [pum gradientFillColor: Color red]
		raise: MessageNotUnderstood