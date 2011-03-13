addTabNamed: aString color: saturatedColor atIndex: anIndex

	| aName paleColor but aBookMorph |
	self flag: #deferred.  "Check to see if former bug that Tabs are somehow not added in requested position is fixed"
	aName _ aString withBlanksTrimmed.
	paleColor _ saturatedColor muchLighter.
	but _ tabsMorph addButtonShowing: aString named: aName selector: #selectTabNamed: arguments: (Array with: aName) atIndex: anIndex.
	but buttonOnColor: saturatedColor.
	but buttonOffColor: paleColor.
	aBookMorph _ BookMorph new pageSize: pageSize.
	aBookMorph removeEverything; color: paleColor; setNameTo: aName; addDressing; insertPageColored: paleColor.
	self insertPage: aBookMorph pageSize: nil atIndex: anIndex.
	^ aBookMorph