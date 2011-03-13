updateFromParagraph
	| newStyle sel oldLast |
	paragraph ifNil: [^ self].
	wrapFlag ifNil: [wrapFlag _ true].
	editor ifNotNil: [sel _ editor selectionInterval.
					editor storeSelectionInParagraph].
	paragraph textStyle = textStyle
		ifTrue: [self fit]
		ifFalse: ["Broadcast style changes to all morphs"
				newStyle _ paragraph textStyle.
				(self firstInChain text: text textStyle: newStyle) recomposeChain.
				sel ifNotNil: [self installEditor selectFrom: sel first to: sel last]].
	sel ifNil: [^ self].

	"If selection is in top line, then recompose predecessor for possible ripple-back"
	predecessor ifNotNil:
		[sel first <= (paragraph lines first last+1) ifTrue:
			[oldLast _ predecessor lastCharacterIndex.
			predecessor paragraph recomposeFrom: oldLast orLineAbove: false.
			oldLast = predecessor lastCharacterIndex
				ifFalse: [predecessor changed. "really only last line"
						self predecessorChanged]]].

	((predecessor~~nil and: [sel first <= paragraph firstCharacterIndex])
		or: [successor~~nil and: [sel first > (paragraph lastCharacterIndex+1)]])
		ifTrue:
		["The selection is no longer inside this paragraph.
		Pass focus to the paragraph that should be in control."
		self releaseEditor.
		self firstInChain withSuccessorsDo:
			[:m |  (sel first between: m firstCharacterIndex
								and: m lastCharacterIndex+1)
					ifTrue: [m installEditor selectFrom: sel first to: sel last.
							m selectionChanged.
							^ self passKeyboardFocusTo: m]].
		^ self].
	editor ifNil:
		["Reinstate selection after, eg, style change"
		self installEditor selectFrom: sel first to: sel last]
