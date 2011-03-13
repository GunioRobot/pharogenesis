likelyCategoryToShow
	"Choose a category to show based on what's already showing and on some predefined heuristics"

	| possible |
	possible _ (scriptedPlayer categoriesForViewer: self) asOrderedCollection.
	self categoryMorphs do:
		[:m | possible remove: m currentCategory ifAbsent: []].

	((possible includes: #'instance variables') and: [scriptedPlayer hasUserDefinedSlots])
		ifTrue:	[^ #'instance variables'].

	((possible includes: #scripts) and: [scriptedPlayer hasUserDefinedScripts])
		ifTrue:	[^ #'scripts'].

	#(basic #'color & border') do:
		[:preferred | (possible includes: preferred) ifTrue: [^ preferred]].
	^ possible size > 0
		ifTrue:
			[possible first]
		ifFalse:
			[#basic]