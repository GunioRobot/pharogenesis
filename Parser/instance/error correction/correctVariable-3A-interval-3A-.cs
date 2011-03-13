correctVariable: proposedVariable interval: spot
	"Correct the proposedVariable to a known variable, or declare it as a new
	variable if such action is requested.  We support declaring lowercase
	variables as temps, and uppercase variables as Globals or ClassVars,
	depending on whether the context is nil (class=UndefinedObject).
	Spot is the interval within the test stream of the variable."

	| alternatives aStream choice userSelection temp binding globalToo |
	"If we can't ask the user for correction, make it undeclared"
	self interactive ifFalse: [ ^ encoder undeclared: proposedVariable ].

	temp _ proposedVariable first isLowercase.
	"First check to see if the requestor knows anything about the variable"
	(temp and: [(binding _ requestor bindingOf: proposedVariable) notNil])
		ifTrue: [^encoder global: binding name: proposedVariable].
	userSelection _ requestor selectionInterval.
	requestor selectFrom: spot first to: spot last.
	requestor select.

	alternatives _ encoder possibleVariablesFor: proposedVariable.

	aStream _ WriteStream on: (String new: 200).
	globalToo _ 0.
	aStream nextPutAll: 'declare ' ,
		(temp ifTrue: ['temp']
			ifFalse: [encoder classEncoding == UndefinedObject
					ifTrue: ['Global']
					ifFalse: [globalToo _ 1.  'Class Variable']]); cr.
	globalToo = 1 ifTrue: [aStream nextPutAll: 'Global'; cr].
	alternatives do:
		[:sel | aStream nextPutAll: sel; cr].
	aStream nextPutAll: 'cancel'.

	choice _ (PopUpMenu
				labels: aStream contents
				lines: (Array with: 1 with: alternatives size+1) )
		startUpWithCaption:
(('Unknown variable: ' , proposedVariable , '
please correct, or cancel:') asText makeBoldFrom: 19 to: 19+proposedVariable size).
	(choice = 0) | (choice > (alternatives size+1))
		ifTrue: [ ^ self fail ].

	requestor deselect.
	requestor selectInvisiblyFrom: userSelection first to: userSelection last.
	choice =1 ifTrue:
			[temp ifTrue: [^ self declareTempAndPaste: proposedVariable]
				ifFalse: [encoder classEncoding == UndefinedObject
					ifTrue: [^ self declareGlobal: proposedVariable]
					ifFalse: [^ self declareClassVar: proposedVariable]]].
	(choice = 2) & (globalToo = 1) ifTrue: [^ self declareGlobal: proposedVariable].
	"Spelling correction"
	self substituteWord: (alternatives at: choice-1-globalToo)
			wordInterval: spot
			offset: 0.
	^ encoder encodeVariable: (alternatives at: choice-1-globalToo)