addCustomMenuItems: aMenu hand: aHandMorph
	"Add morph-specific items to the given menu which was invoked by the given hand."

	super addCustomMenuItems: aMenu hand: aHandMorph.
	aMenu addLine.
	aMenu addUpdating: #romanNumeralString action: #toggleRoman.
	aMenu addUpdating: #antiAliasString action: #toggleAntialias.
	aMenu addLine.
	aMenu add: 'change font...' translated action: #changeFont.
	aMenu balloonTextForLastItem: 'Allows you to change the font used to display the numbers.' translated.
	aMenu add: 'change hands color...' translated action: #changeHandsColor.
	aMenu balloonTextForLastItem: 'Allows you to specify a new color for the hands of the watch.  Note that actual *watch* color can be changed simply by using the halo''s recoloring handle.' translated.
	aMenu add: 'change center color...' translated action: #changeCenterColor.
	aMenu balloonTextForLastItem: 'Allows you to specify a new color to be used during PM hours for the center portion of the watch; during AM hours, a lighter shade of the same color will be used.' translated.