macroBenchmarks 
	"Reports an array of times taken to run a number of macro operations indicative of typical Squeak activity, each run after a full garbageCollection, and with exactly 10Mb of free space available.  In addition it puts up a window with recent VM statistics local to each test."

	"PLEASE TAKE NOTE: The goal of these benchmarks is to provide a simple basis for A/B performance comparisons with a given Squeak image.  For example JIT vs interpreter, new GC vs old, etc.  However, a number of these benchmarks will 'drift' with evolution of the Squeak image, as, for instance, if the number of methods decompiled in macroBenchmark1 were to change.  Therefore it is essential *never* to make comarisons between macroBenchmarks run from two different images."

	"Smalltalk macroBenchmarks #(43215 53122 81336 26927 8993 12607 9024) 400MHz G3"

	| interp time saveMorphs freeCell report fullReport individualTimes |
	individualTimes _ OrderedCollection new.
	fullReport _ String streamContents:
	[:strm | Smalltalk timeStamp: strm.

	"1:	Decompile, pretty-print, and compile a bunch of methods.
		Does not install in classes, so does not flush cache."
	strm cr; cr; nextPutAll: 'Benchmark #1: ';
		print: (time _ self standardTime: [Smalltalk macroBenchmark1]);
		nextPutAll: 'ms'; cr; nextPutAll: '---------------------';
		cr; nextPutAll: Utilities vmStatisticsShortString.
	individualTimes addLast: time.

	"2:	Build morphic tiles for all methods over 800 bytes (;-).
		Does no display."
	strm cr; nextPutAll: 'Benchmark #2: ';
		print: (time _ self standardTime: [SyntaxMorph testAllMethodsOver: 800]);
		nextPutAll: 'ms'; cr; nextPutAll: '---------------------';
		cr; nextPutAll: Utilities vmStatisticsShortString.
	individualTimes addLast: time.

	"3:	Translate the interpreter with inlining.
		Does not include any plugins."
	strm cr; nextPutAll: 'Benchmark #3: ';
		print: (time _ self standardTime: [Smalltalk macroBenchmark2]);
		nextPutAll: 'ms'; cr; nextPutAll: '---------------------';
		cr; nextPutAll: Utilities vmStatisticsShortString.
	individualTimes addLast: time.

	"4:	Run the context step simulator.
		200 iterations printing pi and 15 factorial."
	strm cr; nextPutAll: 'Benchmark #4: ';
		print: (time _ self standardTime: [Smalltalk macroBenchmark3]);
		nextPutAll: 'ms'; cr; nextPutAll: '---------------------';
		cr; nextPutAll: Utilities vmStatisticsShortString.
	individualTimes addLast: time.

	"5:	Run the InterpreterSimulator for 150,000 bytecodes.
		Will only run if you have mini.image in your directory."
	strm cr; nextPutAll: 'Benchmark #5: ';
		print: ((FileDirectory default includesKey: 'mini.image')
		ifTrue: [interp _ InterpreterSimulator new openOn: 'mini.image'.
				time _ self standardTime: [interp runForNBytes: 150000].
				interp close. Display restore.
				time]
		ifFalse: [time _ 0]);
		nextPutAll: 'ms'; cr; nextPutAll: '---------------------';
		cr; nextPutAll: Utilities vmStatisticsShortString.
	individualTimes addLast: time.

	"6:	Open 10 browsers and close them.
		Includes browsing to a specific method."
	strm cr; nextPutAll: 'Benchmark #6: ';
		print: (Smalltalk isMorphic
		ifTrue: [saveMorphs _ self currentWorld submorphs.
				self currentWorld removeAllMorphs.  "heh, heh"
				time _ self standardTime:
					[1 to: 10 do: [:i | Browser fullOnClass: SystemDictionary selector: #macroBenchmarks].
					self currentWorld submorphs do:
						[:m | m delete. self currentWorld doOneCycle]].
				self currentWorld addAllMorphs: saveMorphs.
				time]
		ifFalse: [time _ 0]);
		nextPutAll: 'ms'; cr; nextPutAll: '---------------------';
		cr; nextPutAll: Utilities vmStatisticsShortString.
	individualTimes addLast: time.

	"7:	Play a game of FreeCell with display, while running the MessageTally.
		Thanks to Bob Arning for the clever part of this one."
	strm cr; nextPutAll: 'Benchmark #7: ';
		print: (Smalltalk isMorphic
		ifTrue: ["Play a trivial game of FreeCell with MessageTally and report."
				(freeCell _ FreeCell new) openInWorld.
				time _ self standardTime: [freeCell board pickGame: 1].
				(((report _ self currentWorld firstSubmorph) isKindOf: SystemWindow)
					and: [self currentWorld firstSubmorph label = 'Spy Results'])
					ifTrue: [report delete].
				freeCell delete.
				time]
		ifFalse: [time _ 0]);
		nextPutAll: 'ms'; cr; nextPutAll: '---------------------';
		cr; nextPutAll: Utilities vmStatisticsShortString.
	individualTimes addLast: time.

	strm cr; nextPutAll: '---------------------';
		cr; nextPutAll: 'Total time = '; print: individualTimes sum; nextPutAll: ' milliseconds.'; cr].

	StringHolder new textContents: fullReport; openLabel: 'Macro Benchmark Results'.
	^ individualTimes asArray