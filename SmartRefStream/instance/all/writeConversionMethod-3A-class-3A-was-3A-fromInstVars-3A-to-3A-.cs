writeConversionMethod: sel class: newClass was: oldName fromInstVars: oldList to: newList
	"No method sel was found in newClass.  Ask user to look for the fileIn.  Or help by writing a prototype conversion method.  "

| tell choice code keywords newOthers oldOthers copied |
newClass name = oldName 
	ifTrue: [tell _ 'The class ', oldName]
	ifFalse: [tell _ 'An instance of ', oldName, ' is coming in as an ', newClass name, '.  It'].
tell _ tell, ' has different instance variables 
than before.  It needs a conversion method.  You may:'.

choice _ (PopUpMenu labels: 'Find a conversion file on the disk and file it in
Write a conversion method by editing a prototype') startUpWithCaption: tell. 

choice = 1 ifTrue: [PopUpMenu notify: 'After filing in the conversion file, 
please read-in the object file again.'].	"you need to restart the read-in"

choice = 2 ifTrue: [
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
		ifTrue: [code nextPutAll: '"Instance variables are the same.  Only the order changed.  This method should work as written."']
		ifFalse: [code nextPutAll: '"Be sure to to fill in ', newOthers asArray printString, 
			' and deal with the information in ', oldOthers asArray printString, '"'].

	newClass compile: code contents classified: 'object fileIn'.

	PopUpMenu notify: 'Please complete the following method and 
then read-in the object file again.'.
	Smalltalk browseAllImplementorsOf: sel asSymbol]. 


	"If you write a conversion method beware that the class may need a version number change.  This only happens when two conversion methods in the same class have the same selector name.  (A) The inst var lists of the new and old versions intials as some older set of new and old inst var lists.  or (B) Twice in a row, the class needs a conversion method, but the inst vars stay the same the whole time.  (For an internal format change.)
	If either is the case, fileouts already written with the old (wrong) version number, say 2.  Your method must be able to read files that say version 2 but are really 3, until you expunge the erroneous version 2 files from the universe."

 