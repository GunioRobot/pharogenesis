makeProjectLink: characterStream 
	""

	| attribute oldAttributes thisSel |
	
	sensor keyboard.
	oldAttributes _ paragraph text attributesAt: self pointIndex forStyle: paragraph textStyle.
	thisSel _ self selection.

	attribute _ TextSqkProjectLink new. 
	thisSel _ attribute analyze: self selection asString.

	thisSel ifNil: [^ true].
	beginTypeInBlock ~~ nil
		ifTrue:  "only change emphasisHere while typing"
			[self insertTypeAhead: characterStream.
			emphasisHere _ Text addAttribute: attribute toArray: oldAttributes.
			^ true].
	self replaceSelectionWith: (thisSel asText addAttribute: attribute).
	^ true