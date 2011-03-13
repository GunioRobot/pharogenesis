volumeForTrack: trackIndex put: aNumber

	| newVol oldLeft oldRight oldFullVol left right |
	trackIndex > leftVols size ifTrue: [^ self].
	newVol _ ((aNumber asFloat max: 0.0) min: 1.0) * ScaleFactor.
	oldLeft _ leftVols at: trackIndex.
	oldRight _ rightVols at: trackIndex.
	oldFullVol _ oldLeft max: oldRight.
	oldFullVol = 0 ifTrue: [oldFullVol _ 1.0].
	oldLeft < oldFullVol
		ifTrue: [
			left _ newVol * oldLeft / oldFullVol.
			right _ newVol]
		ifFalse: [
			left _ newVol.
			right _ newVol * oldRight / oldFullVol].
	leftVols at: trackIndex put: left asInteger.
	rightVols at: trackIndex put: right asInteger.
