askRemovedInstVars: classList
	| pairList pairClasses index pls newStruct oldStruct |
	"Ask the author whether these newly removed inst vars need to have their info saved"

	pairList _ OrderedCollection new.
	pairClasses _ OrderedCollection new.
	"Class version numbers:  If it must change, something big happened.  Do need a conversion method then.  Ignore them here."
	classList do: [:cls |
		newStruct _ (cls allInstVarNames).
		oldStruct _ (structures at: cls name ifAbsent: [#(0), newStruct]) allButFirst.
		oldStruct do: [:instVarName |
			(newStruct includes: instVarName) ifFalse: [
				pairList add: cls name, ' ', instVarName.
				pairClasses add: cls]]].

	pairList isEmpty ifTrue: [^ #()].
	[index _ PopUpMenu withCaption: 'These instance variables were removed.
When an old project comes in, instance variables 
that have been removed will lose their contents.
Click on items to remove them from the list.
Click on any whose value is unimportant and need not be saved.'
		chooseFrom: pairList, #('all of these need a conversion method'
						'all of these have old values that can be erased').
	(index <= (pls _ pairList size)) & (index > 0) ifTrue: [
		pairList removeAt: index.
		pairClasses removeAt: index].
	index = (pls + 2) ifTrue: ["all are OK" ^ #()].
	pairList isEmpty | (index = (pls + 1))  "all need conversion, exit"] whileFalse.

	^ pairClasses asSet asArray	"non redundant"