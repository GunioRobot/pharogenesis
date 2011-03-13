setContents
	"return the source code that shows in the bottom pane"
	| sel class strm changeType |
	self clearUserEditFlag.
	currentClassName ifNil: [^ contents _ ''].
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
			^ contents _ (class sourceMethodAt: sel) copy]
		ifTrue: [strm _ WriteStream on: (String new: 100).
			(myChangeSet classChangeAt: currentClassName) do: [:each |
				each = #remove ifTrue: [strm nextPutAll: 'Entire class was removed.'; cr].
				each = #add ifTrue: [strm nextPutAll: 'Entire class was added.'; cr].
				each = #change ifTrue: [strm nextPutAll: 'Class definition was changed.'; cr].
				each = #comment ifTrue: [strm nextPutAll: 'New class comment.'; cr]].
			^ contents _ strm contents].