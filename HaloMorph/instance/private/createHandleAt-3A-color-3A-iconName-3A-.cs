createHandleAt: aPoint color: aColor iconName: iconName 
	| bou handle |
	bou := Rectangle center: aPoint extent: self handleSize asPoint.
	Preferences alternateHandlesLook
		ifTrue: [
			handle := RectangleMorph newBounds: bou color: aColor.
			handle borderWidth: 1.
			handle useRoundedCorners.
			self setColor: aColor toHandle: handle]
		ifFalse: [handle := EllipseMorph newBounds: bou color: aColor].
	""
	handle borderColor: aColor muchDarker.
	handle wantsYellowButtonMenu: false.
	""
	iconName isNil
		ifFalse: [| form | 
			form := ScriptingSystem formAtKey: iconName.
			form isNil
				ifFalse: [| image | 
					image := ImageMorph new.
					image image: form.
					image color: aColor makeForegroundColor.
					image lock.
					handle addMorphCentered: image]].
	""
	^ handle