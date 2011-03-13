contents: aText notifying: aController 
	"The retrieved information has changed and its source must now be 
	updated. In this case, the retrieved information is the method of the 
	selected context."
	| selector classOfMethod category method priorMethod parseNode |
	contextStackIndex = 0 ifTrue: [^ false].
	(self selectedContext isKindOf: MethodContext)
		ifFalse:
			[(self confirm:
'I will have to revert to the method from
which this block originated.  Is that OK?')
				ifTrue: [self resetContext: self selectedContext home]
				ifFalse: [^ false]].
	classOfMethod _ self selectedClass.
	category _ self selectedMessageCategoryName.
	Cursor execute showWhile:
		[method _ classOfMethod
		compile: aText
		notifying: aController
		trailer: #(0 0 0 0)
		ifFail: [^ false]
		elseSetSelectorAndNode: 
			[:sel :methodNode | selector _ sel.
			selector == self selectedMessageName
				ifFalse: [self notify: 'can''t change selector'. ^ false].
			priorMethod _ (classOfMethod includesSelector: selector)
				ifTrue: [classOfMethod compiledMethodAt: selector]
				ifFalse: [nil].
			sourceMap _ methodNode sourceMap.
			tempNames _ methodNode tempNames.
			parseNode _ methodNode].
		method cacheTempNames: tempNames].
	category isNil ifFalse: "Skip this for DoIts"
		[method putSource: aText
				fromParseNode: parseNode
				class: classOfMethod
				category: category
				inFile: 2 priorMethod: priorMethod.
		classOfMethod organization classify: selector under: category].
	contents _ aText copy.
	self selectedContext restartWith: method.
	contextVariablesInspector object: nil.
	self resetContext: self selectedContext.
	^true