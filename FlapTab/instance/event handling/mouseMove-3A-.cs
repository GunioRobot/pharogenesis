mouseMove: evt
	| aPosition newReferentThickness adjustedPosition thick |

	dragged ifFalse: [(thick _ self referentThickness) > 0
			ifTrue: [lastReferentThickness _ thick]].
	((self containsPoint: (aPosition _ evt cursorPoint)) and: [dragged not])
		ifFalse:
			[flapShowing ifFalse: [self showFlap].
			adjustedPosition _ aPosition - evt hand targetOffset.
			(edgeToAdhereTo == #bottom)
				ifTrue:
					[newReferentThickness _ inboard
						ifTrue:
							[self world height - adjustedPosition y]
						ifFalse:
							[self world height - adjustedPosition y - self height]].

			(edgeToAdhereTo == #left)
					ifTrue:
						[newReferentThickness _
							inboard
								ifTrue:
									[adjustedPosition x + self width]
								ifFalse:
									[adjustedPosition x]].

			(edgeToAdhereTo == #right)
					ifTrue:
						[newReferentThickness _
							inboard
								ifTrue:
									[self world width - adjustedPosition x]
								ifFalse:
									[self world width - adjustedPosition x - self width]].

			(edgeToAdhereTo == #top)
					ifTrue:
						[newReferentThickness _
							inboard
								ifTrue:
									[adjustedPosition y + self height]
								ifFalse:
									[adjustedPosition y]].
		
			self isCurrentlySolid ifFalse:
				[(#(left right) includes: edgeToAdhereTo)
					ifFalse:
						[self left: adjustedPosition x]
					ifTrue:
						[self top: adjustedPosition y]].

			self applyThickness: newReferentThickness.
			dragged _ true.
			self fitOnScreen.
			self computeEdgeFraction]