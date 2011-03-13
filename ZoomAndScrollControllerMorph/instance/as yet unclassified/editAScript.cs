editAScript

	| d names reply s |
	d _ self targetScriptDictionary.
	names _ d keys asSortedCollection.
	reply _ (SelectionMenu labelList: names selections: names) startUpWithCaption: 'Script to edit?'.
	reply ifNil: [^ self].
	(s _ ZASMScriptMorph new)
		decompileScript: (d at: reply) named: reply for: self;
		fullBounds;
		align: s center with: self center;
		openInWorld
	