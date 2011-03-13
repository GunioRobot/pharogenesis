showFlap
	| thicknessToUse flapOwner |

	"19 sept 2000 - going for all paste ups"

	flapOwner _ self pasteUpMorph.
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
	referent pasteUpMorph == flapOwner
		ifFalse:
			[flapOwner accommodateFlap: self.  "Make room if needed"
			flapOwner addMorphFront: referent.
			flapOwner startSteppingSubmorphsOf: referent.
			self positionReferent.
			referent adaptToWorld: flapOwner].
	inboard  ifFalse:
		[self adjustPositionVisAVisFlap].
	flapShowing _ true.
	
	flapOwner bringFlapTabsToFront