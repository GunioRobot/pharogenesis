showFlap
	| aWorld thicknessToUse |

	aWorld _ self world.
	self referentThickness <= 0
		ifTrue:
			[thicknessToUse _ lastReferentThickness ifNil: [100].
			self orientation == #horizontal
				ifTrue:
					[referent height: thicknessToUse]
				ifFalse:
					[referent width: thicknessToUse]].
	inboard ifTrue:
		[self stickOntoReferent].  "makes referent my owner, and positions me accordingly"
	referent world == aWorld
		ifFalse:
			[aWorld accommodateFlap: self.  "Make room if needed"
			aWorld addMorphFront: referent.
			aWorld startSteppingSubmorphsOf: referent.
			self positionReferent.
			referent adaptToWorld: aWorld].
	inboard  ifFalse:
		[self adjustPositionVisAVisFlap].
	flapShowing _ true.
	
	aWorld bringFlapTabsToFront