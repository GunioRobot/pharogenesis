readContentsHex
	"retrieve the contents from the external file unless it is too long"
	| f size data hexData s |
	f _ FileStream fileNamed: self fullName. 
	f == nil ifTrue:
		[^ 'For some reason, this file cannot be read'].
	(size _ f size) > 10000
		ifTrue: [data _ f next: 10000. f close]
		ifFalse: [data _ f contentsOfEntireFile].

	s _ WriteStream on: (String new: data size*4).
	0 to: data size-1 by: 16 do:
		[:loc | s nextPutAll: loc hex; space;
			nextPut: $(; print: loc; nextPut: $); space; tab.
		loc+1 to: (loc+16 min: data size) do: [:i | s nextPutAll: (data at: i) hex; space].
		s cr].
	hexData _ s contents.

	size > 10000
		ifTrue: [^ 'First 10k bytes:
------------------
' , hexData]
		ifFalse: [^ hexData].