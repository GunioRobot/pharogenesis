setDistanceToCamera: distance
	| pos oldDistance oldPos aCamera |
	aCamera _ myWonderland getDefaultCamera.
	aCamera _ aCamera getChildren 
		detect:[:any| any getName = 'referencePoint']
		ifNone:[aCamera].
	oldPos _ self getPosition: aCamera.
	pos _ B3DVector3 x: oldPos first y: 0 z: oldPos third.
	oldDistance _ pos length.
	oldDistance abs < 1.0e-5 ifTrue:[
		pos _ 0@0@1.
		oldDistance _ 1].
	pos _ pos * (distance * 0.01 / oldDistance).
	self moveToRightNow: {pos x. oldPos second. pos z} asSeenBy: myWonderland getDefaultCamera undoable: false.