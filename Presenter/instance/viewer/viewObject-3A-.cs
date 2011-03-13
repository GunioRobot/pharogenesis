viewObject: anObject
	"Open up a viewer on the given object"

	|  aViewer aRect aPoint nominalHeight aFlapTab flapLoc |
	anObject isMorph ifTrue: [^ self viewMorph: anObject].  "historic morph/player implementation"

	associatedMorph addMorph: (aViewer _ self nascentPartsViewer).

	"19 sept 2000 - allow flaps in any paste up"
	flapLoc _ associatedMorph "world".
	Preferences viewersInFlaps ifTrue:
		[aViewer setProperty: #noInteriorThumbnail toValue: true.
		aViewer initializeFor: anObject barHeight: 0.
		aViewer enforceTileColorPolicy.
		flapLoc hideViewerFlapsOtherThanFor: anObject.
		aFlapTab _ flapLoc viewerFlapTabFor: anObject.
		aFlapTab referent submorphs do: 
			[:m | (m isKindOf: Viewer) ifTrue: [m delete]].
		aFlapTab referent addMorph: aViewer beSticky.
		aViewer visible: true.
		aFlapTab applyThickness: aViewer width + 25.
		aFlapTab spanWorld.
		aFlapTab showFlap. 
		aViewer position: aFlapTab referent position.
		flapLoc startSteppingSubmorphsOf: aFlapTab.
		^ flapLoc startSteppingSubmorphsOf: aViewer].
		
	aViewer initializeFor: anObject barHeight: 6.
	aViewer enforceTileColorPolicy.
	Preferences automaticViewerPlacement ifTrue:
		[aPoint _ anObject bounds right @ 
			(anObject center y - ((nominalHeight _ aViewer initialHeightToAllow) // 2)).
		aRect _ (aPoint extent: (aViewer width @ nominalHeight)) translatedToBeWithin: flapLoc bounds.
		aViewer position: aRect topLeft.
		aViewer visible: true.
		flapLoc startSteppingSubmorphsOf: aViewer.
		"it's already in the world, somewhat coincidentally"
		^ self].
	anObject primaryHand attachMorph: (aViewer visible: true)