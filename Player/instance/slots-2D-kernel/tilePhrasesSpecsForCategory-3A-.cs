tilePhrasesSpecsForCategory: aCategory
	"Return an array of slot and script names and info for use in a viewer on the receiver.  These can be of two flavors - command and slot."

	| categorySymbol |
	categorySymbol _ aCategory asSymbol.

	(categorySymbol == #'instance variables') ifTrue:		"user-defined instance variables"
		[^ self tilePhrasesSpecsInstanceVariablesCategory].

	(categorySymbol == #scripts) ifTrue:						"user-defined scripts"
		[^ self tileScriptCommands].

	^ (self usablePhraseSpecsIn: (costume categoryElementsFor: categorySymbol))   "all others"


"The format of the specs is illustrated by:
	(slot heading 'the direction'	number	 readWrite player getHeading player setHeading:)
	(command wearCostumeOf: 'change appearance to look like' player)"

