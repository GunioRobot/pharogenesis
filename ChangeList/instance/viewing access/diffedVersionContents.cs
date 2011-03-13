diffedVersionContents
	| thisText change class |
	(listIndex = 0
			or: [changeList size < listIndex])
		ifTrue: [^ ''].
	change _ changeList at: listIndex.
	thisText _ change text.
	class _ change methodClass.
	^ listIndex == changeList size
		ifTrue: [thisText]
		ifFalse: [TextDiffBuilder buildDisplayPatchFrom: (changeList at: listIndex + 1) text to: thisText inClass: class]