readAttribute: aVRMLNodeAttribute from: aVRMLStream
	aVRMLStream skipSeparators.
	self isPrototyping ifTrue:[
		aVRMLStream backup.
		(aVRMLStream next: 2) = 'IS' ifTrue:[
			aVRMLStream discard.
			^self parseIS: aVRMLStream with: aVRMLNodeAttribute.
		].
		aVRMLStream restore.
	].
	^self dispatchOn: aVRMLNodeAttribute type
			in: VRMLRuntimeFieldTypes
			with: aVRMLStream
			ifNone:[^self error:'Unknown attribute type: ',aVRMLNodeAttribute type]