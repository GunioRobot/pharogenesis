contents: aString

	contents = aString ifTrue: [^ self].  "no substantive change"
	contents _ aString.
	self fitContents.
