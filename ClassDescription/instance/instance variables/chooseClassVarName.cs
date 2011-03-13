chooseClassVarName 
	"Present the user with a list of class variable names and answer the one selected, or nil if none"

	| lines labelStream allVars index |
	lines := OrderedCollection new.
	allVars := OrderedCollection new.
	labelStream := (String new: 200) writeStream.
	self withAllSuperclasses reverseDo:
		[:class | | vars |
		vars := class classVarNames asSortedCollection.
		vars do:
			[:var |
			labelStream nextPutAll: var; cr.
			allVars add: var].
		vars isEmpty ifFalse: [lines add: allVars size]].
	labelStream contents isEmpty ifTrue: [^Beeper beep]. "handle nil superclass better"
	labelStream skip: -1 "cut last CR".
	index := (UIManager default chooseFrom: (labelStream contents substrings) lines: lines).
	index = 0 ifTrue: [^ nil].
	^ allVars at: index