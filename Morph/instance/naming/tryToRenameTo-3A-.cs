tryToRenameTo: aName
	"A new name has been submited; make sure it's appropriate, and react accordingly.  This circumlocution provides the hook by which the simple renaming of a field can result in a change to variable names in a stack, etc.  There are some problems to worry about here."

	| aStack |
	(self holdsSeparateDataForEachInstance and: [(aStack _ self stack) notNil])
		ifTrue:
			[self topRendererOrSelf setNameTo: aName.
			aStack reassessBackgroundShape]
		ifFalse:
			[self renameTo: aName]