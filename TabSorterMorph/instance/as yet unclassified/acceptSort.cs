acceptSort
	"Reconstitute the palette based on what is found in the sorter"
	| rejects toAdd oldOwner tabsToUse appearanceMorph oldTop aMenu |
	tabsToUse _ OrderedCollection new.
	rejects _ OrderedCollection new.

	pageHolder submorphs doWithIndex: [:m :i |
		toAdd _ nil.
		(m isKindOf: BookMorph) ifTrue:
			[toAdd _ SorterTokenMorph forMorph: m].
		(m isKindOf: SorterTokenMorph) ifTrue:
			[toAdd _ m morphRepresented.
			(toAdd referent isKindOf: MenuMorph) ifTrue:
				[(aMenu _ toAdd referent) setProperty: #paletteMenu toValue: true.
				((aMenu submorphs size > 1) and: [(aMenu submorphs second isKindOf: MenuItemMorph) and: [aMenu submorphs second contents = 'dismiss this menu']])
					ifTrue:
						[aMenu submorphs first delete.   "delete title"
						aMenu submorphs first delete.   "delete stay-up item"
						(aMenu submorphs first isKindOf: MenuLineMorph) ifTrue:
							[aMenu submorphs first delete]]].
			toAdd removeAllMorphs.
			toAdd addMorph: (appearanceMorph _ m submorphs first).
			appearanceMorph position: toAdd position.
			appearanceMorph lock.
			toAdd fitContents].
		toAdd ifNil:
				[rejects add: m]
			ifNotNil:
				[tabsToUse add: toAdd]].
	tabsToUse size == 0 ifTrue: [^ self inform: 'Sorry, must have at least one tab'].
	book newTabs: tabsToUse.
	book tabsMorph color: pageHolder color.
	oldTop _ self topRendererOrSelf.  "in case some maniac has flexed the sorter"
	oldOwner _ oldTop owner.
	oldTop delete.
	oldOwner addMorphFront: book