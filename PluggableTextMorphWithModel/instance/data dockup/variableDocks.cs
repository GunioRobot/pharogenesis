variableDocks
	"Answer a list of VariableDocks that will handle the interface between me and instance data stored on my behalf on a card"

	^ Array with: (VariableDock new variableName: self defaultVariableName type: #text definingMorph: self morphGetSelector: #getMyText morphPutSelector: #setMyText:)