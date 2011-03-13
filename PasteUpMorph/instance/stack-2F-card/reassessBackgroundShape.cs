reassessBackgroundShape
	"A change has been made which may affect the instance structure of the Card uniclass that holds the instance state, which can also be thought of as the 'card data'."

	| takenNames uniqueName requestedName  variableDocks docks |

	"Caution: still to be done: the mechanism so that when a new instance variable is added, it gets initialized in all subinstances of the receiver's player, which are the cards of this shape.  One needs to take into account here the instance variable names coming in; those that are unchanged should keep their values, but those that have newly arrived should obtain their default values from the morphs on whose behalf they are being maintained in the model"

	true ifTrue: "Cursor wait showWhile:"
		[variableDocks _ OrderedCollection new.  "This will be stored in the uniclass's class-side inst var #variableDocks"
		takenNames _ OrderedCollection new.
		(self submorphs select: [:aMorph | aMorph holdsSeparateDataForEachInstance]) do: 
			[:aMorph |
				docks _ aMorph variableDocks.  
		"Each morph can request multiple variables.  
		This complicates matters somewhat but creates a generality for Fabrk-like uses.
		Each spec is an instance of VariableDock, and it provides a point of departure
		for the negotiation between the PasteUp and its constitutent morphs"
				docks do:
					[:aVariableDock |
						uniqueName _ self player uniqueInstanceVariableNameLike: (requestedName _ aVariableDock variableName) excluding: takenNames.
						uniqueName ~= requestedName ifTrue:
							[aVariableDock variableName: uniqueName.
							aMorph noteNegotiatedName: uniqueName for: requestedName].

						takenNames add: uniqueName].
				variableDocks addAll: docks].
		
		self player class setNewInstVarNames: 
			(variableDocks collect: [:info | info variableName asString]).  "NB: sets up accessors, and removes obsolete ones"
		self player class newVariableDocks: variableDocks]
