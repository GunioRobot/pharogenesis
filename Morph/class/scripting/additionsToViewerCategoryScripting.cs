additionsToViewerCategoryScripting
	"Answer viewer additions for the 'scripting' category"

	^#(
		scripting 
		(

			(command startScript: 'start the given script ticking' ScriptName)
			(command pauseScript: 'make the given script be "paused"' ScriptName)
			(command stopScript: 'make the given script be "normal"' ScriptName)

			(command startAll: 'start the given script ticking in the object and all of its siblings.' ScriptName)
			(command pauseAll: 'make the given script be "paused" in the object and all of its siblings' ScriptName)
			(command stopAll: 'make the given script be "normal" in the object and all of its siblings' ScriptName)

			(command doScript: 'run the given script once, on the next tick' ScriptName)
			(command tellSelfAndAllSiblings: 'run the given script in the object and in all of its siblings' ScriptName)
			(command tellAllSiblings: 'send a message to all siblings' ScriptName)))