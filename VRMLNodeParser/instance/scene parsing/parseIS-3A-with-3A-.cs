parseIS: aVRMLStream with: aVRMLNodeAttribute

	| outerScopeName |
	outerScopeName := aVRMLStream readName.
	^aVRMLNodeAttribute value