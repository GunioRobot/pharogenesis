categoriesForWorld
	"Answer the list of categories given that the receiver is the Player representing a World"

	| aList |
	aList _ #(#'color & border' #'pen trails' playfield collections #'stack navigation') asOrderedCollection.
	aList addFirst: ScriptingSystem nameForScriptsCategory.
	aList addFirst: ScriptingSystem nameForInstanceVariablesCategory.
	aList add: #input.

	^ aList