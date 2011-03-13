fatDefForClass: class

	| newDef oldDef oldStrm newStrm outStrm oldVars newVars addedVars |
	
	class isBehavior ifFalse: [^class definition].
	
	newDef _ class definition.
	oldDef _ (self changeRecorderFor: class) priorDefinition.
	oldDef ifNil: [^ newDef].
	oldDef = newDef ifTrue: [^ newDef].

	oldStrm _ ReadStream on: oldDef.
	newStrm _ ReadStream on: newDef.
	outStrm _ WriteStream on: (String new: newDef size * 2).

	"Merge inst vars from old and new defs..."
	oldStrm upToAll: 'instanceVariableNames'; upTo: $'.
	outStrm 
		nextPutAll: (newStrm upToAll: 'instanceVariableNames'); 
		nextPutAll: 'instanceVariableNames:'.
	newStrm peek = $: ifTrue: [newStrm next].	"may or may not be there, but already written"
	outStrm
		nextPutAll: (newStrm upTo: $'); nextPut: $'.
	oldVars _ (oldStrm upTo: $') findTokens: Character separators.
	newVars _ (newStrm upTo: $') findTokens: Character separators.
	addedVars _ oldVars asSet addAll: newVars; removeAll: oldVars; asOrderedCollection.
	oldVars , addedVars do: [:var | outStrm nextPutAll: var; space].
	outStrm nextPut: $'.

	class isMeta ifFalse:
		["Merge class vars from old and new defs..."
		oldStrm upToAll: 'classVariableNames:'; upTo: $'.
		outStrm nextPutAll: (newStrm upToAll: 'classVariableNames:'); nextPutAll: 'classVariableNames:';
			nextPutAll: (newStrm upTo: $'); nextPut: $'.
		oldVars _ (oldStrm upTo: $') findTokens: Character separators.
		newVars _ (newStrm upTo: $') findTokens: Character separators.
		addedVars _ oldVars asSet addAll: newVars; removeAll: oldVars; asOrderedCollection.
		oldVars , addedVars do: [:var | outStrm nextPutAll: var; space].
		outStrm nextPut: $'].

	outStrm nextPutAll: newStrm upToEnd.
	^ outStrm contents
