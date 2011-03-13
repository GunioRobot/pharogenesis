initialFrameFor: aView
	"Find a plausible initial screen area for the supplied view, which should be a StandardSystemView, taking into account the 'reverseWindowStagger' Preference, the size needed, and other windows currently on the screen.  5/22/96 sw"

	| allOrigins screenRight screenBottom initialExtent putativeOrigin putativeFrame allowedArea staggerOrigin |

	Preferences reverseWindowStagger ifTrue:
		[^ self strictlyStaggeredInitialFrameFor: aView].

	allowedArea _ Display usableArea.
	screenRight _ allowedArea right.
	screenBottom _ allowedArea bottom.
	initialExtent _ aView initialExtent.

	allOrigins _ ScheduledControllers windowOriginsInUse.
	self standardPositions do:  "First see if one of the standard positions is free"
		[:aPosition | (allOrigins includes: aPosition)
			ifFalse:
				[^ (aPosition extent: initialExtent) squishedWithin: allowedArea]].

	staggerOrigin _ self standardPositions first.  "Fallback: try offsetting from top left"
	putativeOrigin _ staggerOrigin.

	[putativeOrigin _ putativeOrigin + StaggerOffset.
	putativeFrame _ putativeOrigin extent: initialExtent.
	(putativeFrame bottom < screenBottom) and:
					[putativeFrame right < screenRight]]
				whileTrue:
					[(allOrigins includes: putativeOrigin)
						ifFalse:
							[^ (putativeOrigin extent: initialExtent) squishedWithin: allowedArea]].
	^ (ScrollBarSetback @ ScreenTopSetback extent: initialExtent) squishedWithin: allowedArea