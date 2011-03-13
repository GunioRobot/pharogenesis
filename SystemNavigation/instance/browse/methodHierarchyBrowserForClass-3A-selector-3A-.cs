methodHierarchyBrowserForClass: aClass selector: sel
	"Create and schedule a message set browser on all implementors of the 
	currently selected message selector. Do nothing if no message is selected."
	"SystemNavigation default 
		methodHierarchyBrowserForClass: ParagraphEditor 
		selector: #isControlActive"
	
	| list tab stab aClassNonMeta isMeta theClassOrMeta |
	aClass ifNil: [^ self].
	aClass isTrait ifTrue: [^ self].
	sel ifNil: [^ self].
	aClassNonMeta := aClass theNonMetaClass.
	isMeta := aClassNonMeta ~~ aClass.
	list := OrderedCollection new.
	tab := ''.
	aClass allSuperclasses reverseDo:
		[:cl |
		(cl includesSelector: sel) ifTrue:
			[list addLast: tab , cl name, ' ', sel].
		tab := tab , '  '].
	aClassNonMeta allSubclassesWithLevelDo:
		[:cl :level |
		theClassOrMeta := isMeta ifTrue: [cl class] ifFalse: [cl].
		(theClassOrMeta includesSelector: sel) ifTrue:
			[stab := ''.  1 to: level do: [:i | stab := stab , '  '].
			list addLast: tab , stab , theClassOrMeta name, ' ', sel]]
	 	startingLevel: 0.
	self browseMessageList: list name: 'Inheritance of ' , sel

