volumeForTrack: i put: aNumber

	| newVol oldLeft oldRight oldFullVol left right |
	newVol _ ((aNumber asFloat max: 0.0) min: 1.0) * ScaleFactor.
	oldLeft _ leftVols at: i.
	oldRight _ rightVols at: i.
	oldFullVol _ oldLeft max: oldRight.
	oldFullVol = 0 ifTrue: [oldFullVol _ 1.0].
	oldLeft < oldFullVol
		ifTrue: [
			left _ newVol * oldLeft / oldFullVol.
			right _ newVol]
		ifFalse: [
			left _ newVol.
			right _ newVol * oldRight / oldFullVol].
	leftVols at: i put: left asInteger.
	rightVols at: i put: right asInteger.
