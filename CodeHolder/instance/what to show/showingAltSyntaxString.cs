showingAltSyntaxString
	"Answer a string characerizing whether altSyntax is showing"

	^ (self showingAltSyntax
		ifTrue:
			['<yes>']
		ifFalse:
			['<no>']), 'altSyntax'