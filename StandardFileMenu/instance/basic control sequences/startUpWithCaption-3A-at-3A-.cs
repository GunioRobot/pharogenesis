startUpWithCaption: aString at: location

	|result|
	result _ super startUpWithCaption: aString at: location.
	result ifNil: [^nil].
	result isDirectory ifTrue:
		[self makeFileMenuFor: result directory.
		 self computeForm.
		 ^self startUpWithCaption: aString at: location].
	result isCommand ifTrue: 
		[result _ self getTypedFileName: result.
		result ifNil: [^nil]].
	canTypeFileName ifTrue: [^self confirmExistingFiles: result].
	^result
	