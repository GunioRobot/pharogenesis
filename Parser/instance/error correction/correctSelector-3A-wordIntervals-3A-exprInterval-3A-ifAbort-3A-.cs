correctSelector: proposedKeyword wordIntervals: spots exprInterval: expInt ifAbort: abortAction
	"Correct the proposedKeyword to some selector symbol, correcting the original text if such action is indicated.  abortAction is invoked if the proposedKeyword couldn't be converted into a valid selector.  Spots is an ordered collection of intervals within the test stream of the for each of the keyword parts."

	| alternatives aStream choice correctSelector userSelection lines firstLine |
	"If we can't ask the user, assume that the keyword will be defined later"
	self interactive ifFalse: [ ^ proposedKeyword asSymbol ].

	userSelection _ requestor selectionInterval.
	requestor selectFrom: spots first first to: spots last last.
	requestor select.
	alternatives _ Symbol possibleSelectorsFor: proposedKeyword.
	self flag: #toBeFixed.
	"alternatives addAll: (MultiSymbol possibleSelectorsFor: proposedKeyword)."

	aStream _ WriteStream on: (String new: 200).
	aStream nextPutAll: (proposedKeyword contractTo: 35); cr.
	firstLine _ 1.
 	alternatives do:
		[:sel | aStream nextPutAll: (sel contractTo: 35); nextPut: Character cr].
	aStream nextPutAll: 'cancel'.
	lines _ Array with: firstLine with: (alternatives size + firstLine).
	
	choice _ (PopUpMenu labels: aStream contents lines: lines)
		startUpWithCaption: 
'Unknown selector, please 
confirm, correct, or cancel'.

	(choice = 0) | (choice > (lines at: 2))
		ifTrue: [ ^ abortAction value ].

	requestor deselect.
	requestor selectInvisiblyFrom: userSelection first to: userSelection last.

	choice = 1 ifTrue: [ ^ proposedKeyword asSymbol ].
	correctSelector _ alternatives at: choice - 1.
	self substituteSelector: correctSelector keywords wordIntervals: spots.
	((proposedKeyword last ~= $:) and: [correctSelector last == $:]) ifTrue: [
		^ abortAction value].
	^ correctSelector.
