morphAsPostscript:aMorph rotated:rotateFlag offsetBy:offset
 | psCanvas |
  psCanvas _ self new.
  psCanvas reset.
  psCanvas bounds:(offset extent:aMorph bounds extent).
  psCanvas topLevelMorph:aMorph.
  psCanvas resetContentRotated: rotateFlag.
  psCanvas fullDrawMorph: aMorph .
  ^psCanvas contents.
