getList
	"Differs from the generic in that here we obtain and cache the raw list, then cons it together with the special '-- all --' item to produce the list to be used in the browser.  This special handling is done in order to avoid excessive and unnecessary reformulation of the list in the step method"

	getRawListSelector == nil ifTrue: ["should not happen!" priorRawList _ nil.  ^ #()].
	model classListIndex = 0 ifTrue: [^ priorRawList _ list _ Array new].
	priorRawList _ model perform: getRawListSelector.
	list := (Array with: ClassOrganizer allCategory), priorRawList.
	^list