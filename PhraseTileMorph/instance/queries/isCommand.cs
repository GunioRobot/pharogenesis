isCommand
	"Answer whether the receiver is a true line of phrase-command.  If not, it is a fragment that will not be able to serve as a line of script on its own"

	| rcvrTile pad |
	pad _ submorphs first.
	(pad isKindOf: TilePadMorph) ifTrue:
		[(submorphs second isKindOf: AssignmentTileMorph) ifTrue: [^ true].
		(((rcvrTile _ pad submorphs first) isKindOf: TileMorph) and: [rcvrTile isPossessive]) ifTrue: [^ false]].
	^ true