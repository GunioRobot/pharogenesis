chooseInstVarThenDo: aBlock 
	"Put up a menu of all the instance variables in the receiver, and when the user chooses one, evaluate aBlock with the chosen variable as its parameter.  7/30/96 sw"

	| lines labelStream vars allVars index |

	lines _ OrderedCollection new.
	allVars _ OrderedCollection new.
	labelStream _ WriteStream on: (String new: 200).
	self withAllSuperclasses reverseDo:
		[:class |
		vars _ class instVarNames.
		vars do:
			[:var |
			labelStream nextPutAll: var; cr.
			allVars add: var].
		vars isEmpty ifFalse: [lines add: allVars size]].
	labelStream isEmpty ifTrue:
		[^ (PopUpMenu labels: ' OK ')
			startUpWithCaption: 'There are no
instance variables.'].
	labelStream skip: -1 "cut last CR".
	index _ (PopUpMenu labels: labelStream contents lines: lines) startUp.
	index = 0 ifTrue: [^ self].
	aBlock value: (allVars at: index)