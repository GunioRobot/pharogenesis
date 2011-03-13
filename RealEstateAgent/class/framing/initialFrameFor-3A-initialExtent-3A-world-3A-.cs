initialFrameFor: aView initialExtent: initialExtent world: aWorld
	"Find a plausible initial screen area for the supplied view, which should be a StandardSystemView, taking into account the 'reverseWindowStagger' Preference, the size needed, and other windows currently on the screen."

	| allOrigins screenRight screenBottom putativeOrigin putativeFrame allowedArea staggerOrigin otherFrames |

	Preferences reverseWindowStagger ifTrue:
		[^ self strictlyStaggeredInitialFrameFor: aView initialExtent: initialExtent world: aWorld].

	allowedArea := self maximumUsableAreaInWorld: aWorld.
	screenRight := allowedArea right.
	screenBottom := allowedArea bottom.

	otherFrames := (aWorld windowsSatisfying: [:w | w isCollapsed not])
					collect: [:w | w bounds].

	allOrigins := otherFrames collect: [:f | f origin].
	(self standardPositionsInWorld: aWorld) do:  "First see if one of the standard positions is free"
		[:aPosition | (allOrigins includes: aPosition)
			ifFalse:
				[^ (aPosition extent: initialExtent) translatedAndSquishedToBeWithin: allowedArea]].

	staggerOrigin := (self standardPositionsInWorld: aWorld) first.  "Fallback: try offsetting from top left"
	putativeOrigin := staggerOrigin.

	[putativeOrigin := putativeOrigin + StaggerOffset.
	putativeFrame := putativeOrigin extent: initialExtent.
	(putativeFrame bottom < screenBottom) and:
					[putativeFrame right < screenRight]]
				whileTrue:
					[(allOrigins includes: putativeOrigin)
						ifFalse:
							[^ (putativeOrigin extent: initialExtent) translatedAndSquishedToBeWithin: allowedArea]].
	^ (self scrollBarSetback @ self screenTopSetback extent: initialExtent) translatedAndSquishedToBeWithin: allowedArea