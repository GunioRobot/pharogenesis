ensureCleanBold
	"This ensures that all character glyphs have at least one pixel of white space on the right
	so as not to cause artifacts in neighboring characters in bold or italic."

	| newGlyphs newXTable newGlyphPos startPos newWidth widthOfGlyph increment lastCol |
	emphasis = 0 ifFalse: [^ self].
    newWidth := glyphs width + maxAscii - minAscii + 1.
    lastCol := Form extent: 1@ glyphs height.
    newGlyphs := Form extent: newWidth @ glyphs height.
    newXTable := Array new: xTable size.
    1 to: minAscii do: [:idx | newXTable at: idx put: (xTable at: idx)].
   
    newGlyphPos := startPos := 0.
    minAscii to: maxAscii do:
      [:idx | 
         newXTable at: idx + 1 put: newGlyphPos.
         widthOfGlyph := (xTable at: idx + 2 ) - (xTable at: idx + 1).
         widthOfGlyph > 0
           ifTrue:
             [newGlyphs copy: (newGlyphPos @ 0 extent: widthOfGlyph @ glyphs height)
                          from: startPos@0 in: glyphs rule: Form over.
              lastCol copy: (0 @ 0 extent: 1 @ glyphs height)
                          from: startPos + widthOfGlyph - 1 @0 in: glyphs rule: Form over.
              increment := lastCol isAllWhite ifTrue: [0] ifFalse: [1].
              startPos := startPos + widthOfGlyph.
              newGlyphPos := newGlyphPos + widthOfGlyph + increment.
             ].
      ].
    maxAscii + 2 to: newXTable size do: [:idx | newXTable at: idx put: newGlyphPos.].
    glyphs := Form extent: newGlyphPos @ glyphs height.
    glyphs copy: (0 @ 0 extent: glyphs extent)
            from: 0@0 in: newGlyphs rule: Form over.
    xTable := newXTable.
"
StrikeFont allInstancesDo: [:f | f ensureCleanBold].
(StrikeFont familyName: 'NewYork' size: 21) ensureCleanBold.
StrikeFont shutDown.  'Flush synthetic fonts'.
"
