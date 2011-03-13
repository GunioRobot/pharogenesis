standardPlayerInWorld: aWorld 
	| figaroMorph |
	standardPlayer ifNil:
		[figaroMorph _ SimpleButtonMorph new label: 'figaro' font: ScriptingSystem fontForTiles.
		figaroMorph target: aWorld; actionSelector: #standardPlayerHit; borderColor: Color black; color: Color blue muchLighter.
		aWorld addMorph: figaroMorph.
		standardPlayer _ figaroMorph assuredCostumee renameTo: 'figaro'.
		aWorld presenter standardPlayer: figaroMorph costumee.
		figaroMorph setBalloonText: 'figaro?'].
	^ standardPlayer