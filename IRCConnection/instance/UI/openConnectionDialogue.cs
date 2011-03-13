openConnectionDialogue
	"open a dialogue for making new connections"
	| dialogue textEntry connectButton y yDelta descMorph textEntryList |
	dialogue _ SystemWindow new.

	y _ 0.
	yDelta _ 0.8 / 5.
	textEntryList _ OrderedCollection new.
	#(
		'server'		server
		'port'		portAsString
		'nick'		nick
		'username'	userName
		'full name'	fullName
	) pairsDo: [ :desc :meth |
		descMorph _ PluggableButtonMorph on: self getState: nil action: nil.
		descMorph
			hResizing: #spaceFill;
			vResizing: #spaceFill;
			label: desc.
		dialogue addMorph: descMorph  frame: (0@y extent: 0.3@yDelta).

		textEntry _ PluggableTextMorph on: self text: meth accept: (meth, ':') asSymbol.
		textEntry 
			extent: 200@20;
			color: (Color r: 1.0 g: 1.0 b: 0.599);
			acceptOnCR: true.
		dialogue addMorph: textEntry frame: (0.3@y extent: 0.7@yDelta).
		textEntryList add: textEntry.

		y _ y + yDelta.
	].

	connectButton _ PluggableButtonMorph on: [
			textEntryList do: [ :m | m hasUnacceptedEdits ifTrue:[ m accept ] ].
			self connect 
		] fixTemps getState: nil action: #value.
	connectButton
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		label: 'connect'.
	dialogue addMorph: connectButton frame: (0@0.8 extent: 1@0.2).

	dialogue setLabel: 'connect to an IRC server'.

	dialogue openInWorld.