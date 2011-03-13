createStandardPlayer
	| aMorph |

	aMorph _ ImageMorph new image: (ScriptingSystem formDictionary at: 'standardPlayer').
	associatedMorph addMorphFront: aMorph.
	standardPlayer _ aMorph assuredCostumee renameTo: '¤'.
	aMorph setBalloonText: 'hrrumph, grr'.
	self positionStandardPlayer.
	^ standardPlayer

	"ScriptingSystem formDictionary at: 'standardPlayer' put: (GIFImports at: 'broom')"