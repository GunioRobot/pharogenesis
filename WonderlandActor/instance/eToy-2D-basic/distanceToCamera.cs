distanceToCamera
	| aCamera |
	aCamera _ myWonderland getDefaultCamera.
	aCamera _ aCamera getChildren 
		detect:[:any| any getName = 'referencePoint']
		ifNone:[aCamera].
	^(self distanceTo: aCamera) * 100