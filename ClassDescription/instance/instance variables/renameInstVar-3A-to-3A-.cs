renameInstVar: oldName to: newName
	| i oldCode newCode parser header body sels |
	(i _ instanceVariables indexOf: oldName) = 0 ifTrue:
		[self error: oldName , ' is not defined in ', self name].
	self allSuperclasses , self withAllSubclasses asOrderedCollection do:
		[:cls | (cls instVarNames includes: newName) ifTrue:
			[self error: newName , ' is already used in ', cls name]].
	(self confirm: 'WARNING: Renaming of instance variables
is subject to substitution ambiguities.
Do you still wish to attempt it?') ifFalse: [self halt].

	"...In other words, this does a dumb text search-and-replace,
	which might improperly alter, eg, a literal string.  As long as
	the oldName is unique, everything should work jes' fine. - di"
	instanceVariables replaceFrom: i to: i with: (Array with: newName).
	self withAllSubclasses do:
		[:cls | sels _ cls selectors.
		sels removeAllFoundIn: #(DoIt DoItIn:).
		sels do:
			[:sel |
			oldCode _ cls sourceCodeAt: sel.
			"Don't make changes in the method header"
			(parser _ cls parserClass new) parseSelector: oldCode.
			header _ oldCode copyFrom: 1 to: (parser endOfLastToken min: oldCode size).
			body _ header size > oldCode size
					ifTrue: ['']
					ifFalse: [oldCode copyFrom: header size+1 to: oldCode size].
			newCode _ header , (body copyReplaceTokens: oldName with: newName).
			newCode ~= oldCode ifTrue:
				[cls compile: newCode
					classified: (cls organization categoryOfElement: sel)
					notifying: nil]].
			cls isMeta ifFalse:
				[oldCode _ cls comment.
				newCode _ oldCode copyReplaceTokens: oldName with: newName.
				newCode ~= oldCode ifTrue:
					[cls comment: newCode]]]