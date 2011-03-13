chooseClassVarName 
	"Present the user with a list of class variable names and answer the one selected, or nil if none"

	| lines labelStream vars allVars index |
	lines _ OrderedCollection new.
	allVars _ OrderedCollection new.
	labelStream _ WriteStream on: (String new: 200).
	self withAllSuperclasses reverseDo:
		[:class |
		vars _ class classVarNames asSortedCollection.
		vars do:
			[:var |
			labelStream nextPutAll: var; cr.
			allVars add: var].
		vars isEmpty ifFalse: [lines add: allVars size]].
	labelStream contents isEmpty ifTrue: [^Beeper beep]. "handle nil superclass better"
	labelStream skip: -1 "cut last CR".
	index _ (UIManager default chooseFrom: (labelStream contents substrings) lines: lines).
	index _ (PopUpMenu labels: labelStream contents lines: lines) startUp.
	index = 0 ifTrue: [^ nil].
	^ allVars at: index
