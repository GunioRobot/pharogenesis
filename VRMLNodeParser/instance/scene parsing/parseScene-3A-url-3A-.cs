parseScene: aVRMLStream url: sceneURL
	| version node |
	version := aVRMLStream resetAndCheckVersion.
	version isNil ifTrue:[^self error:'No VRML file'].
	version first = '2.0' ifFalse:[^self error:'Wrong VRML version (',version first,')'].
	version last = 'utf8' ifFalse:[^self error:'Wrong VRML character definition set (not utf8)'].

	'Reading VRML file' 
		displayProgressAt: Sensor cursorPoint
		from: 0 to: 100
		during:[:bar|
			infoBar := bar.
			scene := VRMLScene new.
			scene fileURL: sceneURL.
			[aVRMLStream skipSeparators.
			aVRMLStream atEnd] whileFalse:[
				node := self parseStatement: aVRMLStream.
				node ifNotNil:[scene addNode: node].
			].
	].
	^scene