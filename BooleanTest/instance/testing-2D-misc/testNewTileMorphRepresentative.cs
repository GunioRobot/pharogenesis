testNewTileMorphRepresentative
 self should: [false newTileMorphRepresentative isKindOf: TileMorph].
 self should: [false newTileMorphRepresentative literal = false].
 self should: [true newTileMorphRepresentative literal = true].