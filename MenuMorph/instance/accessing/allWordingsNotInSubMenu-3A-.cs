allWordingsNotInSubMenu: verbotenSubmenuContents
	| aList aSubMenu |
	"Answer a collection of the wordings of all items and subitems, but omit the stay-up item, and also any items in a submenu whose tag is given by erbotenSubmenuContents"

	aList _ OrderedCollection new.
	self items do:
		[:anItem |
			(anItem selector == #toggleStayUp:) ifFalse:
				[(aSubMenu _ anItem subMenu)
					ifNotNil:
						[(anItem contents asString = verbotenSubmenuContents)
							ifFalse:
								[aList addAll: aSubMenu allWordings]]
					ifNil:
						[aList add: anItem contents asString]]].
	^ aList