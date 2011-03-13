viewMorph: aMorph
	| aPlayer aViewer aPalette aRect aPoint nominalHeight aFlapTab topItem flapLoc |
	Sensor leftShiftDown ifFalse:
		[((aPalette _ aMorph standardPalette) ~~ nil and: [aPalette isInWorld])
			ifTrue:	[^ aPalette viewMorph: aMorph]].

	aPlayer _ (topItem _ aMorph topRendererOrSelf) assuredPlayer.
	aViewer _ self nascentPartsViewer.

	"19 sept 2000 - allow flaps in any paste up"
	flapLoc _ associatedMorph "world".
	Preferences viewersInFlaps ifTrue:
		[aViewer setProperty: #noInteriorThumbnail toValue: true.
		aViewer initializeFor: aPlayer barHeight: 0.
		aViewer enforceTileColorPolicy.
		aViewer fullBounds. "force layout"
		"associatedMorph addMorph: aViewer."		"why???"
		flapLoc hideViewerFlapsOtherThanFor: aPlayer.
		aFlapTab _ flapLoc viewerFlapTabFor: topItem.
		aFlapTab referent submorphs do: 
			[:m | (m isKindOf: Viewer) ifTrue: [m delete]].

		aViewer visible: true.
		aFlapTab applyThickness: aViewer width + 25.
		aFlapTab spanWorld.
		aFlapTab showFlap. 
		aViewer position: aFlapTab referent position.
		aFlapTab referent addMorph: aViewer beSticky.		"moved"
		flapLoc startSteppingSubmorphsOf: aFlapTab.
		flapLoc startSteppingSubmorphsOf: aViewer.
		^ aFlapTab].
		
	aViewer initializeFor: aPlayer barHeight: 6.
	aViewer enforceTileColorPolicy.
	aViewer fullBounds. "force layout"
	Preferences automaticViewerPlacement ifTrue:
		[aPoint _ aMorph bounds right @ 
			(aMorph center y - ((nominalHeight _ aViewer initialHeightToAllow) // 2)).
		aRect _ (aPoint extent: (aViewer width @ nominalHeight)) translatedToBeWithin: flapLoc bounds.
		aViewer position: aRect topLeft.
		aViewer visible: true.
		associatedMorph addMorph: aViewer.
		flapLoc startSteppingSubmorphsOf: aViewer.
		"it's already in the world, somewhat coincidentally"
		^ aViewer].
	aMorph primaryHand attachMorph: (aViewer visible: true).
	^ aViewer