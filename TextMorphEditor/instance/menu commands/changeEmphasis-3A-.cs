changeEmphasis: characterStream 
	"Intercept requests to create a link (Cmd-6).  Make them simpler for end-user editing.  SystemWidows use ParagraphEditor's complex commands."

	| keyCode attribute index colors aPageName target book theSelection url newPage labels |
	"Test if it's really the droids we're looking for..."
	keyCode _ ('0123456789-=' indexOf: sensor keyboardPeek ifAbsent: [1]) - 1.
	keyCode ~= 6 ifTrue: [^ super changeEmphasis: characterStream].
		"underline, bold, etc."
	(morph isKindOf: TextMorphForEditView) ifTrue: [
		^ super changeEmphasis: characterStream].	"if in a browser, show all choices"

	sensor keyboard.  "Yes, it is Cmd-6;  consume the command character"
	theSelection _ self selection.
	colors _ #(black magenta red yellow green blue cyan white).
	labels _ colors, #(active).
	(book _ morph ownerThatIsA: BookMorph) ifNotNil: [
		labels _ labels, #('link to')].
	index _ (PopUpMenu labelArray: labels
							lines: (Array with: colors size)) startUp.
	index = 0 ifTrue: [^ true].
	index <= colors size ifTrue:
		[attribute _ TextColor color: (Color perform: (colors at: index))].
	index = (colors size + 1) ifTrue:
		[attribute _ TextDoIt new.
		theSelection _ attribute analyze: self selection asString].
	index = (colors size + 2) ifTrue:	"Link to a new page, possibly create it"
		["target page must be in memory"
		aPageName _ self selection asString.
		target _ book pageNamed: aPageName.	"later don't bring in all pages!"
		"later offer correction"
		target ifNotNil: [url _ target url.
			url ifNil: [self inform: 'You must send the target page to a server.'.  ^ true].
			attribute _ TextSqkPageLink new. 
			theSelection _ attribute analyze: self selection asString,'<',url,'>'].
		target ifNil: ["add page at end"
			(book valueOfProperty: #keepTogether) 
				ifNotNil: [self inform: 'For now, can''t link in book whose 
pages must be kept together'.  ^ true].
			newPage _ book insertPageSilentlyAtEnd.
			newPage setNameTo: theSelection asString.
			book saveOnUrlPage: newPage.	"write it on the server"
			attribute _ TextSqkPageLink new. 
			theSelection _ attribute analyze: 
				self selection asString,'<', newPage url,'>'].
		].
	self replaceSelectionWith: (theSelection asText addAttribute: attribute).
	^ true