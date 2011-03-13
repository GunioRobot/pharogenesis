selectNewCamera
	| menu sel |
	((self scene cameras isNil) or: [self scene cameras size = 0]) ifTrue: [
		(SelectionMenu selections: #('OK'))
			startUpWithCaption: 'No cameras defined!'.
		^self].
	menu _ SelectionMenu
		selections: self scene cameras keys asArray.
	sel := menu startUp.
	sel ifNotNil: [
		self scene defaultCamera: (self scene cameras at: sel) copy.
		b3DSceneMorph updateUpVectorForCamera: self scene defaultCamera.
		self changed.]