setContents
	"return the source code that shows in the bottom pane"
	| sel class strm what |
	self unlock.
	(classList selection) == nil ifTrue: [^ contents _ ''].
	class _ classList selectedClassOrMetaClass.
	(sel _ messageList selection) == nil
		ifFalse: [
			what _ (myChangeSet atSelector: (sel _ sel asSymbol) class: class).
			what == #remove ifFalse: [
				(class includesSelector: sel) ifFalse: [
					^ contents _ 'was added, but it''s gone! ******'].
				^ contents _ (class sourceMethodAt: sel) copy]
			  ifTrue: [^ contents _ 'remove the method ******']]
		ifTrue: [strm _ WriteStream on: (String new: 100).
			(myChangeSet classChangeAt: class name) do: [:each |
				each = #remove ifTrue: [strm nextPutAll: '**** entire class was removed ****'; cr].
				each = #add ifTrue: [strm nextPutAll: '**** entire class was added ****'; cr].
				each = #change ifTrue: [strm nextPutAll: '**** class definition was changed ****'; cr].
				each = #comment ifTrue: [strm nextPutAll: '**** new class comment ****'; cr]].
			^ contents _ strm contents].