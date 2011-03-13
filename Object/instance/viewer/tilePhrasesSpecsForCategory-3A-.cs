tilePhrasesSpecsForCategory: aCategory
	"Return an array of slot and script names and info for use in a viewer on the receiver.  These can be of two flavors - command and slot."

	^ (self usablePhraseSpecsIn: (self categoryElementsFor: aCategory asSymbol))


"The format of the specs is illustrated by:
	(slot heading 'the direction'	number	 readWrite player getHeading player setHeading:)
	(command wearCostumeOf: 'change appearance to look like' player)"

