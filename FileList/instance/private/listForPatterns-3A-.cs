listForPatterns: anArray
	"Make the list be those file names which match the pattern."

	| sizePad newList |
	newList _ Set new.
	anArray do: [ :pat | newList addAll: (self entriesMatching: pat) ].
	newList _ (SortedCollection sortBlock: self sortBlock) addAll: newList; yourself.
	sizePad _ (newList inject: 0 into: [:mx :entry | mx max: (entry at: 5)])
					asStringWithCommas size - 1.
	newList _ newList collect: [ :e | self fileNameFormattedFrom: e sizePad: sizePad ].

	volList size = 1 ifTrue:
		["Include known servers along with other desktop volumes" 
		^ newList asArray ,
		(ServerDirectory serverNames collect: [:n | '^' , n , self folderString])].
	^ newList asArray