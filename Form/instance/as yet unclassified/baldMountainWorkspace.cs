baldMountainWorkspace
"   -- Reset player, do this, then play -- 
	|  file ff |
Time millisecondsToRun: [
	file _ FileStream oldFileNamed: 'Bald10fpsAll338.forms'.
	file binary.
	file next = 2 ifFalse: [self halt].
	ff _ Form extent: 320@240 depth: 16.
	1 to: 338 by: 2 do:
		[:i | file position: i-1*153613+1.
		ff readFrom: file.
		ff display.
		[i*124>AA msecsSinceStart] whileTrue: [World doOneCycle].
		Sensor yellowButtonPressed ifTrue: [^ file close]].
	file close]

 -- Async version --
 |  file ff byteCount nFrames bytesRead di |
	file _ AsyncFile new open: 'Bald10fpsAll338.forms' forWrite: false.
	ff _ Form extent: 320@240 depth: 16.
	byteCount _ ff bits size * 4.
	nFrames _ 338.
	file primReadStart: file fileHandle fPosition: 1+13 count: byteCount.
	1 to: nFrames by: (di_1) do:
		[:i |
		file waitForCompletion.
		bytesRead _ file primReadResult: file fileHandle
			intoBuffer: ff bits at: 1 count: byteCount//4.
		Sensor anyButtonPressed ifTrue: [^ file close].
		(i+di) <= nFrames ifTrue:
			[file primReadStart: file fileHandle fPosition: (i-1+di)*(byteCount+13)+1+13 count: byteCount].
		ff display.
		[i*124>AA msecsSinceStart] whileTrue: [World doOneCycle].
		].
	file close.
	waitTime

	| ps zps f32 f16 |
	1 to: 338 by: 1 do:
		[:i | ps _ i printString. zps _ ('00000' copyFrom: 1 to: 5 - ps size) , ps.
		f32 _ Form fromFile: (FileStream oldFileNamed:
			'Macintosh HD:Shipping.Receiving:Bald10fps bmps:Bald' , zps , '.BMP').
		f32 displayAt: 0@0.
		f16 _ Form extent: f32 extent depth: 16.
		f32 displayOn: f16 at: 0@0.
		f16 displayAt: 330@0.
		Transcript cr; show: i printString.
		f16 writeUncompressedOnFileNamed:
			'Macintosh HD:Shipping.Receiving:Bald10fps forms:Bald' , zps , '.form'.
		Sensor anyButtonPressed ifTrue: [^ nil]]

	| ps zps  file |
	file _ FileStream newFileNamed: 'Macintosh HD:Shipping.Receiving:Bald10fpsAll338.forms'.
	file binary.
	file nextPut: 2.
	1 to: 338 by: 1 do:
		[:i | ps _ i printString. zps _ ('00000' copyFrom: 1 to: 5 - ps size) , ps.
		(Form fromFileNamed: 'Macintosh HD:Shipping.Receiving:Bald10fps forms:Bald' , zps , '.form') display; writeUncompressedOn: file.
		Sensor anyButtonPressed ifTrue: [^ nil]].
	file close

	-- convert .forms file to .movie format --
	|  out ps zps ff |
	out _ FileStream newFileNamed: 'Bald2minAt10fps.movie'.
	out binary.
	ff _ Form extent: 320@240 depth: 16.
	#(22 320 240 16 338) , (6 to: 32)
		do: [:i | out nextInt32Put: i].
		
	1 to: 1203 by: 1 do:
		[:i | i printString displayAt: 400@0.
		ps _ i printString. zps _ ('00000' copyFrom: 1 to: 5 - ps size) , ps.
		(Form fromFileNamed: 'BackStreet HD:Bald Mt Disk:Bald2 10fps Proc:Bald10.' , zps)
 			displayOn: ff.
		ff display; writeOnMovie: out].
	out close.

	|  file ff |
Time millisecondsToRun: [
	file _ FileStream oldFileNamed: 'Bald10fpsAll338.forms'.
	file binary.
	file next = 2 ifFalse: [self halt].
	ff _ Form extent: 320@240 depth: 16.
	1 to: 338 by: 1 do:
		[:i | ff  readFrom: file.
		ff display.
		Sensor anyButtonPressed ifTrue: [^ file close]].
	file close]

	|  file ff byteCount nFrames filePosition bytesRead waitTime t |
Array with: (Time millisecondsToRun: [
	file _ AsyncFile new open: 'Bald10fpsAll338.forms' forWrite: false.
	ff _ Form extent: 320@240 depth: 16.
	waitTime _ 0.
	byteCount _ ff bits size * 4.
	filePosition _ 1.
	nFrames _ 338.
	file primReadStart: file fileHandle fPosition: filePosition+13 count: byteCount.
	1 to: nFrames by: 1 do:
		[:i |
		t _ Time millisecondClockValue.
		file waitForCompletion.
		waitTime _ waitTime + (Time millisecondClockValue - t).
		bytesRead _ file primReadResult: file fileHandle
			intoBuffer: ff bits at: 1 count: byteCount//4.
		filePosition _ filePosition+13 + bytesRead.
		Sensor anyButtonPressed ifTrue: [^ file close].
		i < nFrames ifTrue:
			[file primReadStart: file fileHandle fPosition: filePosition+13 count: byteCount].
		ff display].
	file close])
	with: waitTime (18400 9798 )

 | ff |
 ff _ Form fromFileNamed: 'Macintosh HD:Shipping.Receiving:Bald10fps forms:Bald00338.form'.
 Time millisecondsToRun: [1 to: 100 do: [:i | ff display]] 100000//1359 73


Try out on-the-fly pixel doubling [dummied for timing]...
 | file f1 f2 f2a pixMap bb1 bb2 |
Time millisecondsToRun: [
	file _ FileStream oldFileNamed: 'Bald10fpsAll338.forms'.
	file binary.
	file next = 2 ifFalse: [self halt].
	f1 _ Form extent: 320@240 depth: 16.
	f2 _ Form extent: 640@480 depth: 16.
	f2a _ Form extent: 320@480 depth: 32.
	f2a bits: f2 bits.
	pixMap _ Bitmap new: 32768.
	1 to: 32768 do: [:i | pixMap at: i put: (i bitOr: (i bitShift: 16))].
	bb1 _ BitBlt destForm: f2a sourceForm: f1 halftoneForm: nil combinationRule: 3 destOrigin: 0@0 sourceOrigin: 0@0 extent: 320@1 clipRect: f2a boundingBox.
	bb1 colorMap: pixMap.
	bb2 _ BitBlt destForm: f2 sourceForm: f2 halftoneForm: nil combinationRule: 3 destOrigin: 0@0 sourceOrigin: 0@0 extent: 640@1 clipRect: f2 boundingBox.
	1 to: 338 by: 1 do:
		[:i | f1  readFrom: file.
		bb1 destOrigin: 0@0; sourceOrigin: 0@0.
		bb1 destOrigin: 0@0; sourceOrigin: 0@0.
		0 to: 239 do:
			[:j |
			bb1 sourceY: j; destY: j*2; copyBits.
			bb2 sourceY: j*2; destY: j*2+1; copyBits].
		f2 display.
		Sensor anyButtonPressed ifTrue: [^ nil]].
	file close
] 104512 53247 39812 338000.0/ 53247 6.34777546152835 6 6
"