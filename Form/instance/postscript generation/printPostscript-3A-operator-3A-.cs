printPostscript:aStream operator:operator
	aStream	gsave; 
			rectclip:(0 @ 0 extent: (width) @ (height)).
	self setColorspaceOn:aStream.
	aStream print:'[ '; cr;
			print:'/ImageType 1'; cr;
			print:'/ImageMatrix [1 0 0 1 0 0]'; cr;
			print:'/MultipleDataSources false'; cr;
			print:'/DataSource level1 { { currentfile '; write:self bytesPerRow;print:' string readhexstring pop }} bind { currentfile /ASCIIHexDecode filter } ifelse'; cr;
			print:'/Width '; write:self paddedWidth; cr;
			print:'/Height '; write:self height; cr;
			print:'/Decode '; print:self decodeArray;  cr;
			print:'/BitsPerComponent '; write:self bitsPerComponent; cr;
			print:'makeDict '; print:operator; cr.
	self depth <= 8 ifTrue:[self storeHexBitsOn:aStream].
	self depth = 16 ifTrue:[self store15To24HexBitsOn:aStream].
	self depth = 32 ifTrue:[self store32To24HexBitsOn:aStream].
	aStream print:$>; cr.
	aStream cr.
	aStream grestore; cr.