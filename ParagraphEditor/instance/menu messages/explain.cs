explain
	"Try to shed some light on what kind of entity the current selection is. 
	The selection must be a single token or construct. Insert the answer after 
	the selection. Send private messages whose names begin with 'explain' 
	that return a string if they recognize the selection, else nil.
	1/15/96 sw: put here intact from BrowserCodeController.  But there's too many things that still don't work, as the explain code was very tightly bound with properties of code browsers.  So for the moment, in the interest of system integrity, we don't permit.  2/5/96 sw"

	| string tiVars cgVars selectors delimitors numbers symbol sorry reply newLine |

	true ifTrue:
		[self flag: #noteToTed.   "Feel like taking this on?  Plenty of things make sense to explain in any text window, but my efforts to elevate the explain facility to more generic use ran out of steam before success."
		^ self inform: 'Sorry, explain is currently available
only in code panes.  Someday, it may be available
in any text pane.  Maybe.'].

	newLine _ String with: Character cr.
	Cursor execute
		showWhile: 
			[sorry _ '"Sorry, I can''t explain that.  Please select a single token, construct, or special character.'.
			sorry _ sorry , (model isUnlocked
							ifTrue: ['"']
							ifFalse: ['  Also, please cancel or accept."']).
			(string _ self selection asString) isEmpty
				ifTrue: [reply _ '']
				ifFalse: 
					[string _ self explainScan: string.
					"Remove space, tab, cr"
					"Temps and Instance vars need only test strings that are 
					all  
					letters"
					(string detect: [:char | (char isLetter or: [char isDigit]) not]
						ifNone: [])
						~~ nil
						ifFalse: 
							[tiVars _ self explainTemp: string.
							tiVars == nil ifTrue: [tiVars _ self explainInst: string]].
					(tiVars == nil and: [model class == Browser])
						ifTrue: [tiVars _ model explainSpecial: string].
					tiVars == nil
						ifTrue: [tiVars _ '']
						ifFalse: [tiVars _ tiVars , newLine].
					"Context, Class, Pool, and Global vars, and Selectors need 
					only test symbols"
					(Symbol hasInterned: string ifTrue: [:symbol | symbol])
						ifTrue: 
							[cgVars _ self explainCtxt: symbol.
							cgVars == nil
								ifTrue: 
									[cgVars _ self explainClass: symbol.
									cgVars == nil ifTrue: [cgVars _ self explainGlobal: symbol]].
							"See if it is a Selector (sent here or not)"
							selectors _ self explainMySel: symbol.
							selectors == nil
								ifTrue: 
									[selectors _ self explainPartSel: string.
									selectors == nil ifTrue: [selectors _ self explainAnySel: symbol]]]
						ifFalse: [selectors _ self explainPartSel: string].
					cgVars == nil
						ifTrue: [cgVars _ '']
						ifFalse: [cgVars _ cgVars , newLine].
					selectors == nil
						ifTrue: [selectors _ '']
						ifFalse: [selectors _ selectors , newLine].
					string size = 1
						ifTrue: ["single special characters"
							delimitors _ self explainChar: string]
						ifFalse: ["matched delimitors"
							delimitors _ self explainDelimitor: string].
					numbers _ self explainNumber: string.
					numbers == nil ifTrue: [numbers _ ''].
					delimitors == nil ifTrue: [delimitors _ ''].
					reply _ tiVars , cgVars , selectors , delimitors , numbers].
			reply size = 0 ifTrue: [reply _ sorry].
			self afterSelectionInsertAndSelect: reply]