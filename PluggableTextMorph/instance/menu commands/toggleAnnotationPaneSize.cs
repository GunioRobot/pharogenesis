toggleAnnotationPaneSize

	| handle origin aHand siblings newHeight lf prevBottom m ht |

	self flag: #bob.		"CRUDE HACK to enable changing the size of the annotations pane"

	owner ifNil: [^self].
	siblings _ owner submorphs.
	siblings size > 3 ifTrue: [^self].
	siblings size < 2 ifTrue: [^self].

	aHand _ self primaryHand.
	origin _ aHand position.
	handle _ HandleMorph new
		forEachPointDo: [:newPoint |
			handle removeAllMorphs.
			newHeight _ (newPoint - origin) y asInteger min: owner height - 50 max: 16.
			lf _ siblings last layoutFrame.
			lf bottomOffset: newHeight.
			prevBottom _ newHeight.
			siblings size - 1 to: 1 by: -1 do: [ :index |
				m _ siblings at: index.
				lf _ m layoutFrame.
				ht _ lf bottomOffset - lf topOffset.
				lf topOffset: prevBottom.
				lf bottomOffset = 0 ifFalse: [
					lf bottomOffset: (prevBottom + ht).
				].
				prevBottom _ prevBottom + ht.
			].
			owner layoutChanged.

		]
		lastPointDo:
			[:newPoint | handle deleteBalloon.
			self halo ifNotNilDo: [:halo | halo addHandles].
		].
	aHand attachMorph: handle.
	handle setProperty: #helpAtCenter toValue: true.
	handle showBalloon:
'Move cursor farther from
this point to increase pane.
Click when done.' hand: aHand.
	handle startStepping

