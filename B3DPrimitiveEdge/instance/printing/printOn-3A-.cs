printOn: aStream
	super printOn: aStream.
	aStream
		nextPut:$(;
		print: (v0 windowPos bitShiftPoint:-12);
		nextPutAll:' - ';
		print: (v1 windowPos bitShiftPoint: -12);
		nextPutAll:' nLines = ';
		print: nLines;
		nextPut:$).