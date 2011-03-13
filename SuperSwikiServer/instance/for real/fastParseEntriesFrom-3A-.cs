fastParseEntriesFrom: aString

	| c first strm xEntryName xCreationTime xModificationTime xIsDirectory xFileSize ch |

	c _ OrderedCollection new.
	first _ true.
	aString linesDo: [ :x |
		first ifFalse: [
			strm _ ReadStream on: x.
			(strm upTo: $ ) = '(DirectoryEntry' ifFalse: [^nil].
			(strm upTo: $ ) = 'name:' ifFalse: [^nil].
			xEntryName _ WriteStream on: String new.
			strm next = $' ifFalse: [^nil].
			[
				ch _ strm next.
				ch = $' and: [(strm peekFor: $') not]
			] whileFalse: [
				xEntryName nextPut: ch.
			].
			xEntryName _ xEntryName contents.
			strm skipSeparators.
			(strm upTo: $ ) = 'creationTime:' ifFalse: [^nil].
			xCreationTime _ (strm upTo: $ ) asNumber.
			(strm upTo: $ ) = 'modificationTime:' ifFalse: [^nil].
			xModificationTime _ (strm upTo: $ ) asNumber.
			(strm upTo: $ ) = 'isDirectory:' ifFalse: [^nil].
			xIsDirectory _ (strm upTo: $ ) = 'true'.
			(strm upTo: $ ) = 'fileSize:' ifFalse: [^nil].
			xFileSize _ (strm upTo: $ ) asNumber.

			c add: (DirectoryEntry 
				name: (xEntryName convertFromEncoding: self encodingName)
				creationTime: xCreationTime 
				modificationTime: xModificationTime 
				isDirectory: xIsDirectory 
				fileSize: xFileSize
			)
		].
		first _ false.
	].
	^c
