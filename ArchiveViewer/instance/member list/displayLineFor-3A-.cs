displayLineFor: aMember
	| stream dateTime index |
	index := self archive members indexOf: aMember.
	stream := WriteStream on: (String new: 60).
	dateTime := Time dateAndTimeFromSeconds: aMember lastModTime. 
	stream
	nextPutAll: (index printString padded: #left to: 4 with: $  );
	space;
		nextPutAll: (aMember uncompressedSize printString padded: #left to: 8 with: $  );
		space; space;
		nextPutAll: (aMember compressedSize printString padded: #left to: 8 with: $  );
		space; space;
		nextPutAll: (aMember crc32String );
		space; space.
	dateTime first printOn: stream format: #(3 2 1 $- 2 1 2).
	stream space; space.
	dateTime second print24: true showSeconds: false on: stream.
	stream space; space;
		nextPutAll: (aMember fileName ).
	^stream contents