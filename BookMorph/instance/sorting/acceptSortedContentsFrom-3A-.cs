acceptSortedContentsFrom: aHolder
	"Update my page list from the given page sorter."

	| goodPages rejects toAdd sqPage |
	goodPages _ OrderedCollection new.
	rejects _ OrderedCollection new.
	aHolder submorphs doWithIndex: [:m :i |
		toAdd _ nil.
		(m isKindOf: PasteUpMorph) ifTrue: [toAdd _ m].
		(m isKindOf: BookPageThumbnailMorph) ifTrue: [
			toAdd _ m page.
			m bookMorph == self ifFalse: [
				"borrowed from another book. preserve the original"
				toAdd _ toAdd veryDeepCopy.	

				"since we came from elsewhere, cached strings are wrong"
				self removeProperty: #allTextUrls.
				self removeProperty: #allText.
			].
		].
		toAdd class == String ifTrue: ["a url"
			toAdd _ pages detect: [:aPage | aPage url = toAdd] ifNone: [toAdd]].
		toAdd class == String ifTrue: [
			sqPage _ SqueakPageCache atURL: toAdd.
			toAdd _ sqPage contentsMorph 
				ifNil: [sqPage copyForSaving]	"a MorphObjectOut"
				ifNotNil: [sqPage contentsMorph]].
		toAdd ifNil: [rejects add: m]
			ifNotNil: [goodPages add: toAdd]].

	self newPages: goodPages.
	goodPages size = 0 ifTrue: [self insertPage].
	rejects size > 0 ifTrue: [self inform: rejects size printString, ' objects vanished in this process.']
