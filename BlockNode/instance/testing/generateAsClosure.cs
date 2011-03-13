generateAsClosure
	"Answer if we're compiling under the closure regime.  If blockExtent has been set by
	analyseTempsWithin:rootNode: et al then we're compiling under the closure regime."
	^blockExtent ~~ nil