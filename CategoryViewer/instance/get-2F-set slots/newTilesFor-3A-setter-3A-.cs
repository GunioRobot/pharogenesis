newTilesFor: aPlayer setter: aSpec
	| ms  argValue |
	"Return universal tiles for a getter on this property.  Record who self is."

	argValue _ aPlayer perform: (ScriptingSystem getterSelectorFor: aSpec second asSymbol).
	ms _ MessageSend receiver: aPlayer selector: aSpec ninth arguments: (Array with: argValue).
	^ ms asTilesIn: aPlayer class