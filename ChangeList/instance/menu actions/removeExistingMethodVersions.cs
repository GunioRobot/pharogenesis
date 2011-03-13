removeExistingMethodVersions
	"Remove all up to date version of entries from the receiver"
	| newChangeList newList str keep cls sel |
	newChangeList := OrderedCollection new.
	newList := OrderedCollection new.

	changeList with: list do:[:chRec :strNstamp | 
			keep := true.
			(cls := chRec methodClass) ifNotNil:[
				str := chRec string.
				sel := cls parserClass new parseSelector: str.
				keep := (cls sourceCodeAt: sel ifAbsent:['']) asString ~= str.
			].
			keep ifTrue:[
					newChangeList add: chRec.
					newList add: strNstamp]].
	newChangeList size < changeList size
		ifTrue:
			[changeList := newChangeList.
			list := newList.
			listIndex := 0.
			listSelections := Array new: list size withAll: false].
	self changed: #list