removeExistingMethodVersions
	"Remove all up to date version of entries from the receiver"
	| newChangeList newList str keep cls sel |
	newChangeList _ OrderedCollection new.
	newList _ OrderedCollection new.

	changeList with: list do:[:chRec :strNstamp | 
			keep _ true.
			(cls _ chRec methodClass) ifNotNil:[
				str _ chRec string.
				sel _ cls parserClass new parseSelector: str.
				keep _ (cls sourceCodeAt: sel ifAbsent:['']) asString ~= str.
			].
			keep ifTrue:[
					newChangeList add: chRec.
					newList add: strNstamp]].
	newChangeList size < changeList size
		ifTrue:
			[changeList _ newChangeList.
			list _ newList.
			listIndex _ 0.
			listSelections _ Array new: list size withAll: false].
	self changed: #list