listForPatterns: anArray
	"Make the list be those file names which match the pattern."

	| sizePad newList |
	newList := Set new.
	anArray do: [ :pat | newList addAll: (self entriesMatching: pat) ].
	newList := (SortedCollection sortBlock: self sortBlock) addAll: newList; yourself.
	sizePad := (newList inject: 0 into: [:mx :entry | mx max: (entry at: 5)])
					asStringWithCommas size - 1.
	newList := newList collect: [ :e | self fileNameFormattedFrom: e sizePad: sizePad ].

	volList size = 1 ifTrue:
		["Include known servers along with other desktop volumes" 
		^ newList asArray ,
		(ServerDirectory serverNames collect: [:n | '^' , n , self folderString])].
	^ newList asArray