debugMenu
	| menu |
	menu := MenuMorph new.
	self fillIn: menu from: { 
		{'Vm statistics' . { self . #vmStatistics}.  'obtain some intriguing data about the vm.'}.
		{'Space left' . { self . #garbageCollect}. 'perform a full garbage-collection and report how many bytes of space remain in the image.'}.
		{ 'Start profiling all Processes' . { self . #startMessageTally } }.
		{ 'Start profiling UI ' . { self . #startThenBrowseMessageTally } }.
		nil.
		{ 'start drawing again' . { #myWorld . #resumeAfterDrawError } }.
		{ 'start stepping again' . { #myWorld . #resumeAfterStepError } }.
		nil.
		{'close all debuggers'. { Utilities. #closeAllDebuggers } }.
		{'restore display (r)'. { World. #restoreMorphicDisplay }. 'repaint the screen -- useful for removing unwanted display artifacts, lingering cursors, etc.' } }.
	self haltOnceEnabled
		ifTrue: [menu
				add: 'Disable halt/inspect once' translated
				target: menu
				action: #clearHaltOnce]
		ifFalse: [menu
				add: 'Enable halt/inspect once' translated
				target: menu
				action: #setHaltOnce].
	^menu
	