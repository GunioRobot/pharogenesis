formsFromStream: stream 
	| reader |
	reader _ self new on: stream reset.
	Cursor read
		showWhile: [reader allImages.
			reader close].
	^reader