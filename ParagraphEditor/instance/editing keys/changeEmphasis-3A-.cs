changeEmphasis: characterStream 
	"Change the emphasis of the current selection or prepare to accept characters with the change in emphasis. Emphasis change amounts to a font change.  Keeps typeahead."
	| keyCode attribute oldAttributes index thisSel colors |		 "control 0..9 -> 0..9"
	keyCode _ ('0123456789-=' indexOf: sensor keyboard ifAbsent: [1]) - 1.
	oldAttributes _ paragraph text attributesAt: startBlock stringIndex forStyle: paragraph textStyle.
	thisSel _ self selection.

	"Decipher keyCodes for Command 0-9..."
	(keyCode between: 1 and: 5) ifTrue:
		[attribute _ TextFontChange fontNumber: keyCode].
	keyCode = 6 ifTrue:
		[colors _ #(black magenta red yellow green blue cyan white).
		index _ (PopUpMenu labelArray: colors , #('Do it' 'Link to comment of class' 'Link to definition of class' 'Link to hierarchy of class' 'Link to method' 'URL' 'Copy hidden info')
							lines: (Array with: colors size)) startUp.
		index = 0 ifTrue: [^ true].
		index <= colors size
		ifTrue:
			[attribute _ TextColor color: (Color perform: (colors at: index))]
		ifFalse:
			[index _ index - colors size.
			index = 1 ifTrue: [attribute _ TextDoIt new.
				thisSel _ attribute analyze: self selection asString].
			index = 2 ifTrue: [attribute _ TextLink new. 
				thisSel _ attribute analyze: self selection asString with: 'Comment'].
			index = 3 ifTrue: [attribute _ TextLink new. 
				thisSel _ attribute analyze: self selection asString with: 'Definition'].
			index = 4 ifTrue: [attribute _ TextLink new. 
				thisSel _ attribute analyze: self selection asString with: 'Hierarchy'].
			index = 5 ifTrue: [attribute _ TextLink new. 
				thisSel _ attribute analyze: self selection asString].
			index = 6 ifTrue: [attribute _ TextURL new. 
				thisSel _ attribute analyze: self selection asString].
			index = 7 ifTrue: ["Copy hidden info"
				self copyHiddenInfo.  ^ true].	"no other action"
		thisSel ifNil: [^ true]].	"Could not figure out what to link to"
		].
	(keyCode between: 7 and: 11) ifTrue:
		[sensor leftShiftDown
		ifTrue:
			[keyCode = 10 ifTrue: [attribute _ TextKern kern: -1].
			keyCode = 11 ifTrue: [attribute _ TextKern kern: 1]]
		ifFalse:
			[attribute _ TextEmphasis perform:
					(#(bold italic narrow underlined struckOut) at: keyCode - 6).
			oldAttributes do:
				[:att | (att dominates: attribute) ifTrue: [attribute turnOff]]]].
	(keyCode = 0) ifTrue:
		[attribute _ TextEmphasis normal].

	beginTypeInBlock ~~ nil
		ifTrue:  "only change emphasisHere while typing"
			[self insertTypeAhead: characterStream.
			emphasisHere _ Text addAttribute: attribute toArray: oldAttributes.
			^ true].
	self replaceSelectionWith: (thisSel asText addAttribute: attribute).
	^ true