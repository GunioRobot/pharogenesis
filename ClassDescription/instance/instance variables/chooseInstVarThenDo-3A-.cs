chooseInstVarThenDo: aBlock 
	"Put up a menu of all the instance variables in the receiver, and when
the user chooses one, evaluate aBlock with the chosen variable as its
parameter.  If the list is 6 or larger, then offer an alphabetical
formulation as an alternative. triggered by a 'show alphabetically' item
at the top of the list."

	| lines labelStream vars allVars index count offerAlpha |
	(count _ self allInstVarNames size) = 0 ifTrue: 
		[^ self inform: 'There are no
instance variables.'].

	allVars _ OrderedCollection new.
	lines _ OrderedCollection new.
	labelStream _ WriteStream on: (String new: 200).
	(offerAlpha _ count > 5)
		ifTrue:
			[lines add: 1.
			allVars add: 'show alphabetically'.
			labelStream nextPutAll: allVars first; cr].
	self withAllSuperclasses reverseDo:
		[:class |
		vars _ class instVarNames.
		vars do:
			[:var |
			labelStream nextPutAll: var; cr.
			allVars add: var].
		vars isEmpty ifFalse: [lines add: allVars size]].
	labelStream skip: -1 "cut last CR".
	(lines size > 0 and: [lines last = allVars size]) ifTrue:
		[lines removeLast].  "dispense with inelegant line beneath last item"
	index _ (UIManager default chooseFrom: (labelStream contents subStrings: {Character cr}) lines: lines
title: 'Instance variables in', self name).
	index = 0 ifTrue: [^ self].
	(index = 1 and: [offerAlpha]) ifTrue: [^ self
chooseInstVarAlphabeticallyThenDo: aBlock].
	aBlock value: (allVars at: index)