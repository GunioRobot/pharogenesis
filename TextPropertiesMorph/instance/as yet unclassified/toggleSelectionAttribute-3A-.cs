toggleSelectionAttribute: newAttribute

	| selText oldAttributes |

	self applyToWholeText ifTrue: [self activeEditor selectAll].
	selText _ self activeEditor selection asText.
	oldAttributes _ selText attributesAt: 1 forStyle: self activeTextMorph textStyle.
	oldAttributes do: [:att |
		(att dominates: newAttribute) ifTrue: [newAttribute turnOff]
	].
	self activeEditor replaceSelectionWith: (selText addAttribute: newAttribute).
	self activeTextMorph updateFromParagraph.