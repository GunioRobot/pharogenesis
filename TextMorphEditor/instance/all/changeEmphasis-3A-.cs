changeEmphasis: characterStream 
	"May be a request to create a link (Cmd-6).  Intercept if so, else call super"
	| keyCode attribute index colors |
	"Test if it's really the droids we're looking for..."
	keyCode _ ('0123456789-=' indexOf: sensor keyboardPeek ifAbsent: [1]) - 1.
	keyCode ~= 6 ifTrue: [^ super changeEmphasis: characterStream "handle other keys"].
	sensor keyboard  "Yes, it is Cmd-6;  consume the command character".

	colors _ #(black magenta red yellow green blue cyan white).
	index _ (PopUpMenu labelArray: colors , #(active)
							lines: (Array with: colors size)) startUp.
	index = 0 ifTrue: [^ true].
	index <= colors size ifTrue:
		[attribute _ TextColor color: (Color perform: (colors at: index))].
	(index - colors size) = 1 ifTrue:
		[attribute _ TextMorphHotLink new sourceString: self selection asString
					targetMorph: morph
					parameterString: (FillInTheBlank
										request: 'Secondary text for this link (or CR)...'
										initialAnswer: '')].
	self replaceSelectionWith: (self selection addAttribute: attribute).
	^ true