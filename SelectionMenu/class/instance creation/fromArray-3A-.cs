fromArray: anArray
	"Construct a menu from anArray.  The elements of anArray must be either:
	*  A pair of the form: <label> <selector>
or	*  The 'dash' (or 'minus sign') symbol

	Refer to the example at the bottom of the method"

	| labelList lines selections anIndex |
	labelList _ OrderedCollection new.
	lines _ OrderedCollection new.
	selections _ OrderedCollection new.
	anIndex _ 0.
	anArray do:
		[:anElement |
			anElement size == 1
				ifTrue:
					[(anElement == #-) ifFalse: [self error: 'badly-formed menu constructor'].
					lines add: anIndex]
				ifFalse:
					[anElement size == 2 ifFalse: [self error: 'badly-formed menu constructor'].
					anIndex _ anIndex + 1.
					labelList add: anElement first.
					selections add: anElement second]].
	^ self labelList: labelList lines: lines selections: selections

"(SelectionMenu fromArray:
	#(	('first label'		moja)
		('second label'	mbili)
		-
		('third label' 	tatu)
		-
		('fourth label'	nne)
		('fifth label'	tano))) startUp"