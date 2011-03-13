addPageOneControlsTo: aLayoutPage 
	"Return a book with pages containing controls"
	| aWorld aHolder spacer button |
	aWorld _ self world.
	aHolder _ aWorld standardHolder.
	spacer _ Morph new color: Color transparent; extent: 1@3.

	button _ SimpleButtonMorph new target: aWorld; borderColor: Color black.
	aLayoutPage color: Color transparent; borderWidth: 0; inset: 0.
	aLayoutPage hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5; centering: #center.

	"Commands sent to the EToyHolder"
	button target: aHolder.
	aHolder eToySpecificButtonNamesAndSelectors "(Client EToyHolder subclasses override)" do:
		[:pair |
			aLayoutPage addMorphBack: (button fullCopy label: pair first;	actionSelector: pair last)].
	aLayoutPage addMorphBack: spacer fullCopy.
	"Commands sent to the Playfield"
	button target: aWorld playfield; color: (Color r: 1.0 g: 0.8 b: 1.0).
	#( 	('All Pens Down'		     lowerAllPens)
        	('All Pens Up'				liftAllPens)
		('Clear Pen Trails'			clearTurtleTrails)
        )
	do:
		[:pair |
			aLayoutPage addMorphBack: (button fullCopy label: pair first;	actionSelector: pair last).
			aLayoutPage addMorphBack: spacer fullCopy].

	"Commands sent to the Holder"
		button target: aHolder; color: (Color r: 1.0 g: 0.8 b: 0.6) lighter.
		#(  
			('Save on File'            saveEToyInFile))
		do:
			[:pair |
				aLayoutPage addMorphBack: (button fullCopy label: pair first;	actionSelector: pair last).
				aLayoutPage addMorphBack: spacer fullCopy]