balloonTextForMethodString
	"Answer suitable balloon text for the receiver thought of as a method belonging to the currently-selected class of a browser tool."

	| aWindow aCodeHolder aClass |
	Preferences balloonHelpInMessageLists
		ifFalse: [^ nil].
	aWindow := self ownerThatIsA: SystemWindow.
	(aWindow isNil or: [((aCodeHolder := aWindow model) isKindOf: CodeHolder) not])
		ifTrue:	[^ nil].
	((aClass := aCodeHolder selectedClassOrMetaClass) isNil or:
		[(aClass includesSelector: contents asSymbol) not])
			ifTrue: [^ nil].
	^ aClass precodeCommentOrInheritedCommentFor: contents asSymbol
