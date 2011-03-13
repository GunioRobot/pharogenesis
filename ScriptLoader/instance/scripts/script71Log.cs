script71Log

"
0004166: Fix for rejected Graphics extensions
Description
The following extensions to the graphics packages have been proposed and rejected:
  Color class>>saturatedRandom
  Form>>dominantColorWithoutTransparent
The attached CS provides code such that Kedama works correctly without the rejected extensions.
'From Squeak3.9alpha of 4 July 2005 [latest update: #7035] on 8 July 2006 at 8:35:26 pm'!
Change Set:		KedamaFix
Date:			8 July 2006
Author:			Andreas Raab

Change set for rejected extensions Color class>>saturatedRandomColor and Form>>dominantColorWithoutTransparent


0004168: Fix for Color's colorPalette: removal
Description
Color>>colorPaletteForDepth: has been removed to avoid the dependency between Color and NaturalLanguageTranslator. The attached change set provides an implementation in ColorPickerMorph and fixes the existing references.

0004169: StrikeFont>>decodedFromRemoteCanvas: does not belong to Graphics
Description
StrikeFont>>decodedFromRemoteCanvas: was included in the graphics package. The attached change set puts it under Nebraska, where it belongs.

0004170: Fix for rejected SmallLand extensions of Graphics
Description
The following proposed extensions of the Graphics package have been rejected:
- Color>>iconOrThumbnailOfSize:
- Form>>iconOrThumbnailOfSize:
- Form>>scaledIntoFormOfSize:
The attached change sets provides them as *Morphic extensions.

0003821: addMonths: does not handle leap years correctly

"
