Object
	subclass: #MIDIInputParser
	instanceVariableNames:
		'cmdActionTable midiPort received rawDataBuffer sysExBuffer ignoreSysEx startTime timeNow state lastSelector lastCmdByte argByte1 argByte2 '
	classVariableNames: 'DefaultMidiTable '
	poolDictionaries: ''
	category: 'Sound-Scores'