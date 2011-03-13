strictlyStaggeredInitialFrameFor: aStandardSystemView
	"Find a plausible initial screen area for the supplied view, given that the 'strictlyStagger' strategy is in effect.  5/22/96 sw"

	| allOrigins screenRight screenBottom initialExtent putativeOrigin putativeFrame allowedArea staggerOrigin |

	allowedArea _ Display usableArea.
	screenRight _ allowedArea right.
	screenBottom _ allowedArea bottom.
	initialExtent _ aStandardSystemView initialExtent.

	allOrigins _ ScheduledControllers windowOriginsInUse.

	putativeOrigin _ self standardPositions first + ((10 * ReverseStaggerOffset x negated) @ 0).
	[(allOrigins includes: putativeOrigin)
		ifFalse:
			[^ (putativeOrigin extent: initialExtent) squishedWithin: allowedArea].
	putativeOrigin _ putativeOrigin + ReverseStaggerOffset.
	putativeFrame _ putativeOrigin extent: initialExtent.
	(putativeFrame bottom < screenBottom) and: [putativeFrame left > ScrollBarSetback]]
				whileTrue.
	^ (ScrollBarSetback @ ScreenTopSetback extent: initialExtent) squishedWithin: allowedArea