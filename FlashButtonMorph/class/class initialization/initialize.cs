initialize
	"FlashButtonMorph initialize"
	ActionHelpText := Dictionary new.
	#(	(getURL:window: 'Jump to URL')
		(gotoFrame: 'Continue playing')
		(gotoLabel: 'Continue playing')
		(gotoNextFrame 'Continue playing')
		(gotoPrevFrame 'Continue playing')
		(actionPlay 'Continue playing')
		(actionStop 'Stop playing')
		(stopSounds 'Stop all sounds')
		(toggleQuality 'Toggle display quality')
	) do:[:spec| ActionHelpText at: spec first put: spec last].