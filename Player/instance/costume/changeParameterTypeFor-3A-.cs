changeParameterTypeFor: aSelector
	"Change the parameter type for the given selector.  Not currently sent, since types are now set by direct manipulation in the Scriptor header.  If this were reinstated someday, there would probably be an issue about getting correct-looking Parameter tile(s) into the Scriptor header(s)"

	| current typeChoices typeChosen |
	current _ self typeforParameterFor: aSelector.
	typeChoices _ Vocabulary typeChoices.
	typeChosen _ (SelectionMenu selections: typeChoices lines: #()) startUpWithCaption: 
		('Choose the TYPE
for the parameter (currently ', current, ')').
	self setParameterFor: aSelector toType: typeChosen

