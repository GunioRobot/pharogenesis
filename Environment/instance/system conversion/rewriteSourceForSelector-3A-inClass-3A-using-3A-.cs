rewriteSourceForSelector: selector inClass: aClass using: envtForVar
	"Rewrite the source code for the method in question so that all global references out of the direct access path are converted to indirect global references.  This is done by parsing the source with a lenient parser able to find variables in any environment.  Then the parse tree is consulted for the source code ranges of each reference that needs to be rewritten and the pattern to which it should be rewritten.  Note that assignments, which will take the form
	envt setValueOf: #GlobalName to: ...
may generate spurious message due to agglutination of keywords with the value expression."

	| code methodNode edits varName eName envt |
	code _ aClass sourceCodeAt: selector.
	methodNode _ Compiler new parse: code in: aClass notifying: nil.
	edits _ OrderedCollection new.
	methodNode encoder globalSourceRanges do:
		[:tuple |   "{ varName. srcRange. store }"
		(aClass bindingOf: (varName _ tuple first asSymbol)) notNil ifFalse:
			["This is a remote global.  Add it as reference to be edited."
			edits addLast: { varName. tuple at: 2. tuple at: 3 }]].
	"Sort the edits by source position."
	edits _ edits asSortedCollection: [:a :b | a second first < b second first].
	edits reverseDo:
		[:edit | varName _ edit first.
		(eName _ envtForVar at: varName ifAbsent: [nil]) ifNotNil:
			["If varName is not already exported, define an export method"
			envt _ self at: eName.
			(envt class includesSelector: varName) ifFalse:
				[envt class compile: (self exportMethodFor: varName)
						 classified: 'exports'].
			"Replace each access out of scope with a proper remote reference"
			code _ code copyReplaceFrom: edit second first
						to: edit second last
						with: eName , ' ' , varName]].

	aClass compile: code classified: (aClass organization categoryOfElement: selector)