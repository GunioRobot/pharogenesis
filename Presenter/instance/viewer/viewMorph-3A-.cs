viewMorph: aMorph
	| aPlayer aViewer aPalette aRect aPoint nominalHeight aFlapTab topItem |
	Sensor leftShiftDown ifFalse:
		[((aPalette _ aMorph standardPalette) ~~ nil and: [aPalette isInWorld])
			ifTrue:	[^ aPalette viewMorph: aMorph]].

	aPlayer _ (topItem _ aMorph topRendererOrSelf) assuredPlayer.
	associatedMorph addMorph: (aViewer _ self nascentPartsViewer).

	Preferences viewersInFlaps ifTrue:
		[aViewer setProperty: #noInteriorThumbnail toValue: true.
		aViewer initializeFor: aPlayer barHeight: 0.
		aViewer enforceTileColorPolicy.
		associatedMorph world hideViewerFlapsOtherThanFor: aPlayer.
		aFlapTab _ associatedMorph world viewerFlapTabFor: topItem.
		aFlapTab referent submorphs do: 
			[:m | (m isKindOf: Viewer) ifTrue: [m delete]].
		aFlapTab referent addMorph: aViewer beSticky.
		aViewer visible: true.
		aFlapTab applyThickness: aViewer width + 25.
		aFlapTab showFlap. 
		aViewer position: aFlapTab referent position.
		associatedMorph world startSteppingSubmorphsOf: aFlapTab.
		^ associatedMorph world startSteppingSubmorphsOf: aViewer].
		
	aViewer initializeFor: aPlayer barHeight: 6.
	aViewer enforceTileColorPolicy.
	Preferences automaticViewerPlacement ifTrue:
		[aPoint _ aMorph bounds right @ 
			(aMorph center y - ((nominalHeight _ aViewer initialHeightToAllow) // 2)).
		aRect _ (aPoint extent: (aViewer width @ nominalHeight)) translatedToBeWithin: associatedMorph world bounds.
		aViewer position: aRect topLeft.
		aViewer visible: true.
		associatedMorph world startSteppingSubmorphsOf: aViewer.
		"it's already in the world, somewhat coincidentally"
		^ self].
	aMorph primaryHand attachMorph: (aViewer visible: true)