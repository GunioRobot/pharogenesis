wantsDroppedMorph: aMorph event: evt

	^ (aMorph isKindOf: TileMorph) or:
	   [(aMorph isKindOf: ScriptEditorMorph) or:
	   [(aMorph isKindOf: CompoundTileMorph) or:
	   [aMorph isKindOf: CommandTilesMorph]]]
