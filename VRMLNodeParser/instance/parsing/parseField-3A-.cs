parseField: aVRMLStream
	| fieldType fieldValue |
	aVRMLStream backup.
	fieldType := aVRMLStream readName.
	fieldValue := self dispatchOn: fieldType
						in: VRMLFieldTypes
						with: aVRMLStream
						ifNone:[nil].
	aVRMLStream restoreIf: fieldValue isNil.
	^fieldValue