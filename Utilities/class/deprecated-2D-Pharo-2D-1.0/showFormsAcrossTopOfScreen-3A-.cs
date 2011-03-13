showFormsAcrossTopOfScreen: aFormList
	"Display the given array of forms across the top of the screen, wrapping to subsequent lines if needed.    Useful for example for looking at sets of rotations and animations.  6/10/96 sw"
	"self showFormsAcrossTopOfScreen: {Cursor currentCursor asCursorForm}"
	
	self deprecated: 'Use ''Form showFormsAcrossTopOfScreen:'' instead.' on: '10 July 2009' in: #Pharo1.0.
	^ Form showFormsAcrossTopOfScreen: aFormList