addCustomMenuItems: menu hand: aHandMorph
	super addCustomMenuItems: menu hand: aHandMorph.
	menu addLine.
	envelope updateSelector = #ratio: ifTrue:
		[menu add: 'choose denominator...' action: #chooseDenominator:].
	menu add: 'adjust scale...' action: #adjustScale:.
	SoundPlayer isReverbOn
		ifTrue: [menu add: 'turn reverb off' target: SoundPlayer selector: #stopReverb]
		ifFalse: [menu add: 'turn reverb on' target: SoundPlayer selector: #startReverb].
	menu addLine.
	menu add: 'get sound from lib' action: #chooseSound:.
	menu add: 'put sound in lib' action: #saveSound:.
	menu add: 'read sound from disk...' action: #readFromDisk:.
	menu add: 'save sound on disk...' action: #saveToDisk:.
	menu add: 'save library on disk...' action: #saveLibToDisk:.
