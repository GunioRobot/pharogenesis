readHeaderChunk

	| chunkType chunkSize division |
	chunkType _ self readChunkType.
	chunkType = 'RIFF' ifTrue:[chunkType _ self riffSkipToMidiChunk].
	chunkType = 'MThd' ifFalse: [^ self error: 'missing MIDI file header chunk'].
	chunkSize _ self readChunkSize.
	fileType _ self next16BitWord.
	trackCount _ self next16BitWord.
	division _ self next16BitWord.
	(division anyMask: 16r8000)
		ifTrue: [self error: 'SMPTE time formats are not yet supported']
		ifFalse: [ticksPerQuarter _ division].
	maxNoteTicks _ 12 * 4 * ticksPerQuarter.
		"longest acceptable note; used to detect stuck notes"

	"sanity checks"
	chunkSize = 6
		ifFalse: [self report: 'unusual MIDI header size ', chunkSize printString].
	(#(0 1 2) includes: fileType)
		ifFalse: [self report: 'unusual MIDI file type ', fileType printString].

	Transcript
		show: 'Reading Type ', fileType printString, ' MIDI File (';
		show: trackCount printString, ' tracks, ';
		show: ticksPerQuarter printString, ' ticks per quarter note)';
		cr.
