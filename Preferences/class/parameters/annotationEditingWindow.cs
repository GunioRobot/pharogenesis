annotationEditingWindow
	"Answer a window affording editing of annotations"

	| aPanel ins outs current aMorph aWindow aButton info pair standardHeight |
	standardHeight _ 140.
	Smalltalk isMorphic ifFalse: [self error: 'annotations can be edited only in morphic'].
	aPanel _ AlignmentMorph newRow extent: 300 @ standardHeight.
	ins _ AlignmentMorph newColumn extent: 150 @ standardHeight.
	ins color: Color green muchLighter.
	ins enableDrop: true; beSticky.
	outs _ AlignmentMorph newColumn extent: 150 @ standardHeight.
	outs color: Color red muchLighter.
	outs enableDrop: true; beSticky.
	aPanel addMorph: outs; addMorphFront: ins.
	outs position: (ins position + (200 @ 0)).
	current _ self defaultAnnotationRequests.
	info _ self annotationInfo.
	current do:
		[:sym | pair _ info detect: [:aPair | aPair first == sym].
		aMorph _ StringMorph new contents: pair first.
		aMorph setBalloonText: pair last.
		aMorph enableDrag: true.
		aMorph
			on: #startDrag
			send: #startDrag:with:
			to: aMorph.
		ins addMorphBack: aMorph].
	info do:
		[:aPair | 
			(current includes: aPair first) 
				ifFalse:
					[aMorph _ StringMorph new contents: aPair first.
					aMorph setBalloonText: aPair last.
					aMorph enableDrag: true.
					aMorph
						on: #startDrag
						send: #startDrag:with:
						to: aMorph.
					outs addMorph: aMorph]].
	aPanel layoutChanged.
	aWindow _ SystemWindowWithButton new setLabel: 'Annotations'.
	aButton _ SimpleButtonMorph new target: Preferences;
		actionSelector: #acceptAnnotationsFrom:; arguments: (Array with: aWindow); label: 'apply'; borderWidth: 0; borderColor: Color transparent; color: Color transparent.
	aButton submorphs first color: Color blue.
	aButton setBalloonText: 'After moving all the annotations you want to the left (green) side, and all the ones you do NOT want to the right (pink) side, hit this "apply" button to have your choices take effect.'.
	aWindow buttonInTitle: aButton; adjustExtraButton.
	^ aPanel wrappedInWindow: aWindow

	"Preferences annotationEditingWindow openInHand"