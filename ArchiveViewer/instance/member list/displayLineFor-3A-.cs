displayLineFor: aMember
	| stream dateTime |
	stream := WriteStream on: (String new: 60).
	dateTime := Time dateAndTimeFromSeconds: aMember lastModTime. 
	stream
		nextPutAll: (aMember uncompressedSize printString padded: #left to: 8 with: $  );
		space;
		nextPutAll: (aMember compressedSize printString padded: #left to: 8 with: $  );
		space; space;
		nextPutAll: (aMember crc32String );
		space; space.
	dateTime first printOn: stream format: #(3 2 1 $- 2 1 2).
	stream space.
	dateTime second print24: true showSeconds: false on: stream.
	stream space; space;
		nextPutAll: (aMember fileName ).
	^stream contents