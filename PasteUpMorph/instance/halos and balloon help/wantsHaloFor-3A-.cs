wantsHaloFor: aSubMorph
	"Answer whether the receiver wishes for a mouse-over halo to be produced for aSubMorph"

	^ wantsMouseOverHalos == true and:
		 [self visible and:
			[isPartsBin ~~ true and:
				[self dropEnabled and:
					[self isWorldMorph not or: [aSubMorph renderedMorph isLikelyRecipientForMouseOverHalos]]]]]

	"The odd logic at the end of the above says...

		*  If we're an interior playfield, then if we're set up for mouseover halos, show em.
		*  If we're a World that's set up for mouseover halos, only show 'em if the putative
				recipient is a SketchMorph.

	This (old) logic was put in to suit a particular need in early e-toy days and seems rather strange now!"