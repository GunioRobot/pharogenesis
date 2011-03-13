correctSelector: proposedKeyword wordIntervals: spots exprInterval: expInt ifAbort: abortAction fullSearch: tryHard 
	"Correct the proposedKeyword to some selector symbol, correcting the original text if such action is indicated.  abortAction is invoked if the user the proposedKeyword couldn't be converted into a valid selector.  Spots is an ordered collection of intervals within the test stream of the for each of the keyword parts."

	| alternatives aStream choice correctSelector userSelection lines maybePeriod maybeDblKeyword firstLine i |

	"If we can't ask the user, assume that the keyword will be defined later"
	self interactive ifFalse: [ ^ proposedKeyword asSymbol ].

	userSelection _ requestor selectionInterval.
	requestor selectFrom: spots first first to: spots last last.
	requestor select.

	alternatives _ tryHard
		ifFalse: [ Symbol possibleSelectorsFor: proposedKeyword ]
		ifTrue: [ Symbol morePossibleSelectorsFor: proposedKeyword ].

	aStream _ WriteStream on: (String new: 200).
	aStream nextPutAll: (proposedKeyword contractTo: 35); cr.
 	maybePeriod _ maybeDblKeyword _ false.
	firstLine _ 1.
	proposedKeyword numArgs = 0 ifTrue:
		["Unary selector may be a variable after missing period."
 		maybePeriod _ true.  firstLine _ 2.
		aStream nextPutAll: 'insert missing period'; cr]
		ifFalse:
		[self breakIfLikely: proposedKeyword intoSel1Sel2Break:
			[:sel1 :sel2 :break |
			maybeDblKeyword _ true.  firstLine _ 3.
			aStream nextPutAll: '(' , sel1 , ') ' , sel2; cr.
			aStream nextPutAll: sel1 , ' (' , sel2 , ')'; cr]].
 	alternatives do:
		[:sel | aStream nextPutAll: (sel contractTo: 35); nextPut: Character cr].
	aStream nextPutAll: 'cancel'.
	lines _ Array with: firstLine with: (alternatives size + firstLine).
	tryHard ifFalse:
		[aStream cr; nextPutAll: 'try harder'.
		lines _ lines copyWith: (alternatives size + firstLine + 1)].
	
	choice _ (PopUpMenu labels: aStream contents lines: lines)
		startUpWithCaption: 
'Unknown selector, please 
confirm, correct, or cancel'.

	(maybePeriod and: [choice = 2]) ifTrue:
		[i _ requestor nextTokenFrom: spots first first direction: -1.
		self substituteWord: '.' wordInterval: (i+1 to: i) offset: 0.
		^ self restart].
	(maybeDblKeyword and: [choice between: 2 and: 3]) ifTrue:
		[choice = 2 ifTrue: 
			[i _ requestor nextTokenFrom: (spots at: break+1) first direction: -1.
			self substituteSelector: #( '(' ')' )
				wordIntervals: (Array with: (expInt first-2 to: expInt first-3)
								with: (i+1 to: i))]
			ifFalse:
			[i _ requestor nextTokenFrom: (spots at: break) last direction: 1.
			self substituteSelector: #( '(' ')' )
				wordIntervals: (Array with: (i to: i-1)
								with: (expInt last+1 to: expInt last))].
		^ self restart].
	tryHard not & (choice > lines last) ifTrue:
		[^ self correctSelector: proposedKeyword wordIntervals: spots
				exprInterval: expInt ifAbort: abortAction fullSearch: true ]. 

	(choice = 0) | (choice > (lines at: 2))
		ifTrue: [ ^ abortAction value ].

	requestor deselect.
	requestor selectInvisiblyFrom: userSelection first to: userSelection last.

	(choice = 1)
		ifTrue: [ ^ proposedKeyword asSymbol ].

	correctSelector _ alternatives at: 
		(maybeDblKeyword
			ifTrue: [choice - 3]
			ifFalse: [maybePeriod
					ifTrue: [choice - 2]
					ifFalse: [choice - 1]]).
	self substituteSelector: correctSelector keywords wordIntervals: spots.
	^ correctSelector.
