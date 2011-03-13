replaceSilently: old to: new
	"text-replace any part of a method.  Used for class and pool variables.  Don't touch the header.  Not guaranteed to work if name appears in odd circumstances"
	| oldCode newCode parser header body sels oldName newName |

	oldName _ old asString.
	newName _ new asString.
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