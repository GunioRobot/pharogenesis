fullBounds
	"Extend my bounds by the shadow offset when carrying morphs."

	| bnds |
	bnds _ super fullBounds.
	submorphs isEmpty
		ifTrue: [^ bnds ]
		ifFalse: [^ bnds topLeft corner: bnds  bottomRight + self shadowOffset].