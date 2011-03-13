changeEmphasis: characterStream keyEvent: keyEvent
	"Change the emphasis of the current selection or prepare to
	accept characters with the change in emphasis. Emphasis
	change amounts to a font change. Keeps typeahead."
	
	| keyCode attribute oldAttributes index thisSel colors extras |

	"control 0..9 -> 0..9"
	keyCode := ('0123456789-=' indexOf: keyEvent keyCharacter ifAbsent: [1]) - 1.

	oldAttributes := paragraph text attributesAt: self pointIndex forStyle: paragraph textStyle.
	thisSel := self selection.

	"Decipher keyCodes for Command 0-9..."
	(keyCode between: 1 and: 5) ifTrue: [
		attribute := TextFontChange fontNumber: keyCode
	].

	keyCode = 6 ifTrue: [
		| labels lines | 
		colors := #(#black #magenta #red #yellow #green #blue #cyan #white ).
		extras := (self class name = #TextMorphEditor and: [(self morph isKindOf: TextMorphForEditView) not])
						ifTrue: ["not a system window" #()]
						ifFalse: [#('Link to comment of class' 'Link to definition of class' 'Link to hierarchy of class' 'Link to method' )].

		
		labels := colors , #('choose color...' 'Do it' 'Print it' ) , extras , #('be a web URL link' 'Edit hidden info' 'Copy hidden info' ).
		lines := Array with: colors size + 1.
		index := UIManager default chooseFrom: labels lines: lines.
		index = 0 ifTrue: [ ^ true].
			
		index <= colors size ifTrue: [
			attribute := TextColor color: (Color perform: (colors at: index))
		]
		ifFalse: [
			index := index - colors size - 1. "Re-number!!!"

			index = 0 ifTrue: [
				attribute := self chooseColor
			].

			index = 1 ifTrue: [
				attribute := TextDoIt new.
				thisSel := attribute analyze: self selection asString
			].

			index = 2 ifTrue: [
				attribute := TextPrintIt new.
				thisSel := attribute analyze: self selection asString
			].

			extras size = 0 & (index > 2) ifTrue: [
				index := index + 4 "skip those"
			].

			index = 3 ifTrue: [
				attribute := TextLink new.
				thisSel := attribute analyze: self selection asString with: 'Comment'
			].

			index = 4 ifTrue: [
				attribute := TextLink new.
				thisSel := attribute analyze: self selection asString with: 'Definition'
			].

			index = 5 ifTrue: [
				attribute := TextLink new.
				thisSel := attribute analyze: self selection asString with: 'Hierarchy'
			].

			index = 6 ifTrue: [
				attribute := TextLink new.
				thisSel := attribute analyze: self selection asString
			].
		
			index = 7 ifTrue: [
				attribute := TextURL new.
				thisSel := attribute analyze: self selection asString
			].
		
			index = 8 ifTrue: [
				"Edit hidden info"
				thisSel := self hiddenInfo. "includes selection"
				attribute := TextEmphasis normal
			].

			index = 9 ifTrue: [
				"Copy hidden info"
				self copyHiddenInfo.
				^ true
			].
		
			"no other action"
			thisSel
				ifNil: [ ^ true ]
		]
	].

	(keyCode between: 7 and: 11) ifTrue: [
		keyEvent leftShiftDown ifTrue: [
			keyCode = 10 ifTrue: [
				attribute := TextKern kern: -1
			].
			keyCode = 11 ifTrue: [
				attribute := TextKern kern: 1
			]
		]
		ifFalse: [
			attribute := TextEmphasis perform: (#(#bold #italic #narrow #underlined #struckOut ) at: keyCode - 6).
			oldAttributes
						do: [:att | (att dominates: attribute) ifTrue: [attribute turnOff]]
		]
	].

	keyCode = 0
		ifTrue: [attribute := TextEmphasis normal].

	beginTypeInBlock ~~ nil ifTrue: [
		"only change emphasisHere while typing"
		self insertTypeAhead: characterStream.
		emphasisHere := Text addAttribute: attribute toArray: oldAttributes.
		^ true
	].

	self
		replaceSelectionWith: (thisSel asText addAttribute: attribute).
		
	^ true
