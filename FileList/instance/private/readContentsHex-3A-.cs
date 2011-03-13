readContentsHex: brevity
	"retrieve the contents from the external file unless it is too long.
	  Don't create a file here.  Check if exists."
	| f size data hexData s |

	f _ directory oldFileOrNoneNamed: self fullName. 
	f == nil ifTrue: [^ 'For some reason, this file cannot be read'].
	(size _ f size) > 5000 & (brevity)
		ifTrue: [data _ f next: 10000. f close. brevityState _ #briefHex]
		ifFalse: [data _ f contentsOfEntireFile. brevityState _ #fullHex].

	s _ WriteStream on: (String new: data size*4).
	0 to: data size-1 by: 16 do:
		[:loc | s nextPutAll: loc hex; space;
			nextPut: $(; print: loc; nextPut: $); space; tab.
		loc+1 to: (loc+16 min: data size) do: [:i | s nextPutAll: (data at: i) hex; space].
		s cr].
	hexData _ s contents.

	size > 5000 & (brevity)
		ifTrue: [^ 'First 5k bytes:
------------------
' , hexData]
		ifFalse: [^ hexData].
