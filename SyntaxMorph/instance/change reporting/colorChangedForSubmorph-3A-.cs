colorChangedForSubmorph: colorPatch
	| sel newSel cc ms phrase completeMsg |
	"reporting a color change"

	(self nodeClassIs: MessageNode) ifFalse: [^ nil].
	(sel _ self selector) ifNil: [^ nil].
	(Color colorNames includes: sel) | (sel == #r:g:b:) ifFalse: [^ nil].
		"a standard color name"
	"replace self with new tiles from the color"
	(newSel _ (cc _ colorPatch color) name) 
		ifNil: [ms _ MessageSend receiver: Color selector: #r:g:b: arguments: 
				(Array with: cc red with: cc green with: cc blue).
			phrase _ ms asTilesIn: Color globalNames: true]
		ifNotNil: [ms _ MessageSend receiver: Color selector: newSel arguments: #().
			phrase _ ms asTilesIn: Color globalNames: true].
	self deletePopup.
	completeMsg _ self isNoun ifTrue: [self] ifFalse: [owner].
	completeMsg owner replaceSubmorph: completeMsg by: phrase.
	"rec setSelection: {rec. nil. rec}."
	phrase acceptIfInScriptor.