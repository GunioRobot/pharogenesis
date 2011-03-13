baseUniclass
	"Answer the uniclass that new instances should be instances of.  This protocol is primarily intended for the Player lineage, but can get sent to a MorphicModel subclass when the project-loading mechanism is scrambling to fix up projects that have naming conflicts with the project being loaded."

	| curr |
	curr _ self.
	[curr theNonMetaClass superclass name endsWithDigit]
		whileTrue:
			[curr _ curr superclass].
	^ curr

"PlayWithMe1 baseUniclass"