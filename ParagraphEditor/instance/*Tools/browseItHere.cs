browseItHere
	"Retarget the receiver's window to look at the selected class, if appropriate.  3/1/96 sw"
	| aSymbol foundClass b |
	(((b := model) isKindOf: Browser) and: [b couldBrowseAnyClass])
		ifFalse: [^ view flash].
	model okToChange ifFalse: [^ view flash].
	self selectionInterval isEmpty ifTrue: [self selectWord].
	(aSymbol := self selectedSymbol) isNil ifTrue: [^ view flash].

	self terminateAndInitializeAround:
		[foundClass := (Smalltalk at: aSymbol ifAbsent: [nil]).
			foundClass isNil ifTrue: [^ view flash].
			(foundClass isKindOf: Class)
				ifTrue:
					[model systemCategoryListIndex: 
						(model systemCategoryList indexOf: foundClass category).
		model classListIndex: (model classList indexOf: foundClass name)]]