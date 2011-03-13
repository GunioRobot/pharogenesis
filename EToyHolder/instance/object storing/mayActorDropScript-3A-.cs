mayActorDropScript: aMorph
	"aMorph is in the scaffolding and has a script.  Should we dump it?  From tck 11/97"

	| ok |
	ok _ self confirm: 'Player ', aMorph externalName,
		' is inside the Toys book and has a script.
May I remove the script?'.
	ok ifTrue: [aMorph jettisonScripts].