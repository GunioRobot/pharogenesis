standardPartsWindow
	| aPartsWindow aWorld |
	aPartsWindow _ ScriptingSystem newStandardPartsBin wrappedInPartsWindowWithTitle: 'Standard Parts'.
	aWorld _ (associatedMorph == nil or: [associatedMorph isInWorld not])
		ifTrue:		[self currentWorld]
		ifFalse:		[associatedMorph world].
	aWorld addMorph: aPartsWindow.  "So that closeEditing won't bomb"
	aPartsWindow closeEditing.  "a bit redundant but gets the last details right"
	^ aPartsWindow