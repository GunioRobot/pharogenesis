diffedVersionContents
	| thisText |
	(listIndex = 0 or: [changeList size < listIndex])
		ifTrue: [^ ''].
	thisText _ (changeList at: listIndex) text.
	^ listIndex == changeList size
		ifTrue:
			[thisText]
		ifFalse:
			[TextDiffBuilder buildDisplayPatchFrom: (changeList at: (listIndex + 1)) text to: thisText]