createStandardPlayer
	| aMorph |

	aMorph _ ImageMorph new image: (ScriptingSystem formAtKey: 'standardPlayer').
	associatedMorph addMorphFront: aMorph.
	standardPlayer _ aMorph assuredPlayer renameTo: 'dot'.
	aMorph setBalloonText: '...'.
	self positionStandardPlayer.
	^ standardPlayer