addStopStepGoButtonsTo: aPasteUpMorph
	| controls |
	controls _ ScriptingSystem scriptControlButtons.
	controls setToAdhereToEdge: #bottomLeft.
	aPasteUpMorph addMorphBack: controls.
	stopButton _ controls submorphs first.
	stepButton _ controls submorphs second.
	goButton _ controls submorphs third