writeConversionMethod: sel class: newClass was: oldName fromInstVars: oldList to: newList
	"No method sel was found in newClass.  Writing a default conversion method."

	| code keywords newOthers oldOthers copied |

	code _ WriteStream on: (String new: 500).
	keywords _ sel keywords.
	code nextPutAll: (keywords at: 1); nextPutAll: ' varDict '; 
			nextPutAll: (keywords at: 2); nextPutAll: ' smartRefStrm'; cr; tab.
	newOthers _ newList asOrderedCollection "copy".
	oldOthers _ oldList asOrderedCollection "copy".
	copied _ OrderedCollection new.
	newList do: [:instVar |
		(oldList includes: instVar) ifTrue: [
			instVar isInteger ifFalse: [copied add: instVar].
			newOthers remove: instVar.
			oldOthers remove: instVar]].
	code nextPutAll: '"These variables are automatically stored into the new instance '.
	code nextPutAll: copied asArray printString; nextPut: $. .
	code cr; tab; nextPutAll: 'This method is for additional changes.'; 
		nextPutAll: ' Use statements like (foo _ varDict at: ''foo'')."'; cr; cr; tab.
	(newOthers size = 0) & (oldOthers size = 0) 
		ifTrue: [code nextPutAll: '"Instance variables are the same.  Only the order changed.  This method should work as written."'].
	(newOthers size > 0) ifTrue: [code nextPutAll: '"New variables: ', newOthers asArray printString, '  If a non-nil value is needed, please assign it."\' withCRs].
	(oldOthers size > 0) ifTrue: [code nextPutAll: '	"These are going away ', oldOthers asArray printString, '.  Possibly store their info in another variable?"'].

	newClass compile: code contents classified: 'object fileIn'.


	"If you write a conversion method beware that the class may need a version number change.  This only happens when two conversion methods in the same class have the same selector name.  (A) The inst var lists of the new and old versions intials as some older set of new and old inst var lists.  or (B) Twice in a row, the class needs a conversion method, but the inst vars stay the same the whole time.  (For an internal format change.)
	If either is the case, fileouts already written with the old (wrong) version number, say 2.  Your method must be able to read files that say version 2 but are really 3, until you expunge the erroneous version 2 files from the universe."

 