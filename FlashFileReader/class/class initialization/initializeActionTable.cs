initializeActionTable
	"Create and return a new SWF action table"
	"FlashFileReader initializeActionTable"
	ActionTable := Array new: 12.
	ActionTable atAllPut: #processUnknownAction:.
	#(
		(processActionGotoFrame:	1)
		(processActionGetURL:		3)
		(processActionNextFrame:	4)
		(processActionPrevFrame:	5)
		(processActionPlay:			6)
		(processActionStop:			7)
		(processActionToggleQuality:	8)
		(processActionStopSounds:	9)
		(processActionWaitForFrame:	10)
		(processActionSetTarget:		11)
		(processActionGotoLabel:		12)
	) do:[:spec|
			ActionTable at: spec last put: spec first.
	].
