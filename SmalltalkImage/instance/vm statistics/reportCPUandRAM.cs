reportCPUandRAM
	"Write several text files with useful analysis for profiling purposes.
	Overwrites any existing report.
	SmalltalkImage current reportCPUandRAM
	"	

	| stream tally |
	"VM statistics (Memory use and GC, mainly)"
	stream := FileStream forceNewFileNamed: 'Log-MemoryStats.txt'.
	[ stream nextPutAll: self vmStatisticsReportString ] 
		ensure: [ stream close ].
	
	"Process list"
	stream := FileStream forceNewFileNamed: 'Log-ProcessList.txt'.
	[
		ProcessBrowser new processNameList 
			do: [ :each | 
				stream nextPutAll: each; cr ]
	] ensure: [ stream close ].

"Fork all these, so they run in sequence, as the system is back running"
[
	"Process taking most CPU"
	stream := FileStream forceNewFileNamed: 'Log-ThePig.txt'.
	ProcessBrowser dumpPigStackOn: stream andClose: true.
	
	"Tally of all processes"
	stream := FileStream forceNewFileNamed: 'Log-FullTally.txt'.
	[
		tally := MessageTally new.
		tally spyAllEvery: 1 on: [ (Delay forMilliseconds: 1000) wait ].
		tally report: stream ] ensure: [ stream close ].

	"Memory Analysis"
	stream := FileStream forceNewFileNamed: 'Log-MemoryAnalysis.txt'.
	[ SpaceTally new printSpaceAnalysis: 1 on: stream ]
		ensure: [ stream close ]

] forkNamed: 'CPU usage analysis'