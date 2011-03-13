methodHierarchyBrowserForClass: aClass selector: sel
	"Create and schedule a message set browser on all implementors of the 
	currently selected message selector. Do nothing if no message is selected."
	| list tab stab aClassNonMeta isMeta theClassOrMeta |

	aClass ifNil: [^ self].
	sel ifNil: [^ self].
	aClassNonMeta _ aClass theNonMetaClass.
	isMeta _ aClassNonMeta ~~ aClass.
	list _ OrderedCollection new.
	tab _ ''.
	aClass allSuperclasses reverseDo:
		[:cl |
		(cl includesSelector: sel) ifTrue:
			[list addLast: tab , cl name, ' ', sel].
		tab _ tab , '  '].
	aClassNonMeta allSubclassesWithLevelDo:
		[:cl :level |
		theClassOrMeta _ isMeta ifTrue: [cl class] ifFalse: [cl].
		(theClassOrMeta includesSelector: sel) ifTrue:
			[stab _ ''.  1 to: level do: [:i | stab _ stab , '  '].
			list addLast: tab , stab , theClassOrMeta name, ' ', sel]]
	 	startingLevel: 0.
	Smalltalk browseMessageList: list
		name: 'Inheritance of ' , sel

"Utilities methodHierarchyBrowserForClass: ParagraphEditor selector: #isControlActive"