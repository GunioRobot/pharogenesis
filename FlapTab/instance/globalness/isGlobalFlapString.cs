isGlobalFlapString
	"Answer a string to construct a menu item representing control over whether the receiver is or is not a global flap"

	^ (self isGlobalFlap
		ifTrue:
			['<yes>']
		ifFalse:
			['<no>']), 'global (sharable by all projects)'