setContents
	"return the source code that shows in the bottom pane"

	| sel class strm changeType |
	self clearUserEditFlag.
	currentClassName ifNil: [^ contents _ myChangeSet preambleString ifNil: ['']].
	class _ self selectedClassOrMetaClass.
	(sel _ currentSelector) == nil
		ifFalse: [changeType _ (myChangeSet atSelector: (sel _ sel asSymbol) class: class).
			changeType == #remove
				ifTrue: [^ contents _ 'Method has been removed (see versions)'].
			changeType == #addedThenRemoved
				ifTrue: [^ contents _ 'Added then removed (see versions)'].
			class ifNil: [^ contents _ 'Method was added, but cannot be found!'].
			(class includesSelector: sel)
				ifFalse: [^ contents _ 'Method was added, but cannot be found!'].
			contents _ class sourceCodeAt: sel.
			(#(prettyPrint colorPrint prettyDiffs altSyntax) includes: contentsSymbol) ifTrue:
				[contents _ class compilerClass new
					format: contents in: class notifying: nil contentsSymbol: contentsSymbol].
			self showingAnyKindOfDiffs
				ifTrue: [contents _ self diffFromPriorSourceFor: contents].
			^ contents _ contents asText makeSelectorBoldIn: class]
		ifTrue: [strm _ WriteStream on: (String new: 100).
			(myChangeSet classChangeAt: currentClassName) do:
				[:each |
				each = #remove ifTrue: [strm nextPutAll: 'Entire class was removed.'; cr].
				each = #addedThenRemoved ifTrue: [strm nextPutAll: 'Class was added then removed.'].
				each = #rename ifTrue: [strm nextPutAll: 'Class name was changed.'; cr].
				each = #add ifTrue: [strm nextPutAll: 'Class definition was added.'; cr].
				each = #change ifTrue: [strm nextPutAll: 'Class definition was changed.'; cr].
				each = #reorganize ifTrue: [strm nextPutAll: 'Class organization was changed.'; cr].
				each = #comment ifTrue: [strm nextPutAll: 'New class comment.'; cr.
				]].
			^ contents _ strm contents].