askAddedInstVars: classList
	| pairList pairClasses index pls newStruct oldStruct |
	"Ask the author whether these newly added inst vars need to be non-nil"

	pairList _ OrderedCollection new.
	pairClasses _ OrderedCollection new.
	"Class version numbers:  If it must change, something big happened.  Do need a conversion method then.  Ignore them here."
	classList do: [:cls |
		newStruct _ (cls allInstVarNames).
		oldStruct _ (structures at: cls name ifAbsent: [#(0), newStruct]) allButFirst.
		newStruct do: [:instVarName |
			(oldStruct includes: instVarName) ifFalse: [
				pairList add: cls name, ' ', instVarName.
				pairClasses add: cls]]].

	pairList isEmpty ifTrue: [^ #()].
	[index _ UIManager default 
		chooseFrom: pairList, #('all of these need a non-nil value'
						'all of these are OK with a nil value')
		title:
'These instance variables were added.
When an old project comes in, newly added 
instance variables will have the value nil.
Click on items to remove them from the list.
Click on any for which nil is an OK value.'.
	(index <= (pls _ pairList size)) & (index > 0) ifTrue: [
		pairList removeAt: index.
		pairClasses removeAt: index].
	index = (pls + 2) ifTrue: ["all are OK" ^ #()].
	pairList isEmpty | (index = (pls + 1)) "all need conversion, exit"] whileFalse.

	^ pairClasses asSet asArray	"non redundant"