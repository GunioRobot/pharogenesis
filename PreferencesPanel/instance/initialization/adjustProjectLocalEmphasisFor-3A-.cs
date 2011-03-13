adjustProjectLocalEmphasisFor: aSymbol
	"Somewhere, the preference represented by aSymbol got changed from being one that is truly global to one that varies by project, or vice-versa.  Get my panel right -- this involves changing the emphasis on the item"

	| aWindow toFixUp allMorphs emphasis |
	(aWindow _ self containingWindow) ifNil: [^ self].
	emphasis _ (Preferences preferenceAt: aSymbol ifAbsent: [^ self]) localToProject
		ifTrue:	[TextEmphasis bold emphasisCode "bold for local-to-project"]
		ifFalse:	[TextEmphasis normal emphasisCode "normal for global"].
	allMorphs _ IdentitySet new.
	aWindow allMorphsAndBookPagesInto: allMorphs.
	toFixUp _ allMorphs select:
		[:m | (m isKindOf: StringMorph) and: [m contents = aSymbol]].
	toFixUp do:
		[:aStringMorph | aStringMorph emphasis: emphasis]

	