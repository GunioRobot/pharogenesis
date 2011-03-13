setNewContentsFrom: stringOrTextOrNil
	"Using stringOrTextOrNil as a guide, set the receiver's contents afresh.  If the input parameter is nil, the a default value stored in a property of the receiver, if any, will supply the new initial content.  This method is only called when a VariableDock is attempting to put a new value.  This is still messy and ill-understood and not ready for prime time."

	| defaultValue tt atts |
	stringOrTextOrNil ifNotNil: [^ self newContents: stringOrTextOrNil 
		fromCard: (self valueOfProperty: #cardInstance)].
		   "Well, totally yuk -- emergency measure late on eve of demo"
	defaultValue := self valueOfProperty: #defaultValue 
					ifAbsent: [atts := text attributesAt: 1.	"Preserve size, emphasis"
						tt := text copyReplaceFrom: 1 to: text size
								with: 'blankText'.
						atts do: [:anAtt | tt addAttribute: anAtt].
						tt].
	self contents: defaultValue deepCopy wrappedTo: self width.
